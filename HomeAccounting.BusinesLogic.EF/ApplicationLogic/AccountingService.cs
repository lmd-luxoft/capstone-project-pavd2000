using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HomeAccounting.BusinesLogic.EF.Domain;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public class AccountingService : IAccountingService
    {
        IDbContextFactory<DomainContext> _contextFactory;
        public AccountingService(IDbContextFactory<DomainContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void CreateAccount(AccountModel accountModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = CreateAccountByAccountModel(accountModel);
                if (accountModel.Type == AccountType.Deposit)
                {
                    var deposit = (Deposit)account;
                    if (!string.IsNullOrWhiteSpace(deposit.Bank?.BIK))
                    {
                        var bank = ctx.Banks.Where(x => x.BIK == deposit.Bank.BIK).FirstOrDefault();
                        if (bank != null)
                        {
                            deposit.Bank = bank;
                        }
                    }
                    ctx.Add(deposit);
                }
                else
                {
                    ctx.Add(account);
                }
                ctx.SaveChanges();
                accountModel.Id = account.Id;
            }
        }

        public void DeleteAccountById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = ctx.Accounts.FirstOrDefault(x => x.Id == id);
                if(account == null)
                {
                    throw new InvalidOperationException("Не найден счет для удаления!");
                }
                ctx.Remove(account);
                ctx.SaveChanges();
            }
        }

        public AccountModel GetAccountById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = ctx.Accounts.FirstOrDefault(x => x.Id == id);
                return CreateAccountModelByType(account);
            }
        }
        private Account CreateAccountByAccountModel(AccountModel accountModel)
        {
            Account account;
            switch (accountModel.Type)
            {
                case AccountType.Simple:
                    account = CreateSimpleAccount(accountModel);
                    break;
                case AccountType.Deposit:
                    account = CreateDeposit((DepositModel)accountModel);
                    break;
                case AccountType.Property:
                    account = CreateProperty((PropertyModel)accountModel);
                    break;
                case AccountType.Cash:
                    account = CreateCash((CashModel)accountModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Неизвестный тип счета {accountModel.Type}");
            }
            return account;
        }

        private AccountModel CreateAccountModelByType(Account account)
        {
            if (account == null)
            {
                return null;
            }
            if (account is Deposit)
            {
                return CreateDepositModel((Deposit)account);
            }
            else if (account is Cash)
            {
                return CreateCashModel((Cash)account);
            }
            else if (account is Property)
            {
                return CreatePropertyModel((Property)account);
            }
            else
            {
                return CreateSimpleAccountModel(account);
            }
        }


        public List<AccountModel> SelectByFilter(AccountModelFilter filter)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var accounts = ctx.Accounts.AsQueryable();
                accounts.OrderByDescending(x => x.Id);
                accounts.Skip((filter.Page - 1) * filter.OnPage).Take(filter.OnPage);
                return accounts.ToList().Select(x => CreateAccountModelByType(x)).ToList();
            }
        }

        public void UpdateAccount(AccountModel accountModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = CreateAccountByAccountModel(accountModel);
                ctx.Attach(account);
                ctx.Update(account);
                ctx.SaveChanges();
            }
        }

        private Deposit CreateDeposit(DepositModel depositModel)
        {
            return new Deposit
            {
                Id = depositModel.Id,
                Balance = depositModel.Balance,
                CreationDate = depositModel.CreationDate,
                Title = depositModel.Title,
                NumberOfBankAccount = depositModel.NumberOfBankAccount,
                Bank = new Bank()
                {
                    BIK = depositModel.Bank?.BIK,
                    CorrAccount = depositModel.Bank?.CorrAccount,
                    Title = depositModel.Bank?.Title,
                },
                Percent = depositModel.Percent,
                PercentType = depositModel.PercentType
            };
        }

        private DepositModel CreateDepositModel(Deposit deposit)
        {
            return new DepositModel
            {
                Id = deposit.Id,
                Balance = deposit.Balance,
                CreationDate = deposit.CreationDate,
                Title = deposit.Title,
                NumberOfBankAccount = deposit.NumberOfBankAccount,
                Bank = new BankModel()
                {
                    BIK = deposit.Bank?.BIK,
                    CorrAccount = deposit.Bank?.CorrAccount,
                    Title = deposit.Bank?.Title,
                },

                Percent = deposit.Percent,
                PercentType = deposit.PercentType,
                Type = AccountType.Deposit
            };
        }

        private Account CreateSimpleAccount(AccountModel accountModel)
        {
            return new Account
            {
                Id = accountModel.Id,
                Balance = accountModel.Balance,
                CreationDate = accountModel.CreationDate,
                Title = accountModel.Title
            };
        }

        private AccountModel CreateSimpleAccountModel(Account account)
        {
            return new AccountModel
            {
                Id = account.Id,
                Balance = account.Balance,
                CreationDate = account.CreationDate,
                Title = account.Title,
                Type = AccountType.Simple
            };
        }

        private Property CreateProperty(PropertyModel propertyModel)
        {
            return new Property()
            {
                Id = propertyModel.Id,
                Balance = propertyModel.Balance,
                CreationDate = propertyModel.CreationDate,
                BasePrice = propertyModel.BasePrice,
                Title = propertyModel.Title,
                Location = propertyModel.Location,
                Type = propertyModel.PropertyType
            };
        }

        private PropertyModel CreatePropertyModel(Property property)
        {
            return new PropertyModel()
            {
                Id = property.Id,
                Balance = property.Balance,
                CreationDate = property.CreationDate,
                BasePrice = property.BasePrice,
                Title = property.Title,
                Location = property.Location,
                Type = AccountType.Property
            };
        }

        private Cash CreateCash(CashModel cashModel)
        {
            return new Cash
            {
                Id = cashModel.Id,
                Balance = cashModel.Balance,
                CreationDate = cashModel.CreationDate,
                Title = cashModel.Title,
                Banknotes = cashModel.Banknotes,
                Monets = cashModel.Monets
            };
        }

        private CashModel CreateCashModel(Cash cash)
        {
            return new CashModel
            {
                Id = cash.Id,
                Balance = cash.Balance,
                CreationDate = cash.CreationDate,
                Title = cash.Title,
                Banknotes = cash.Banknotes,
                Monets = cash.Monets,
                Type = AccountType.Cash

            };
        }

    }
}
