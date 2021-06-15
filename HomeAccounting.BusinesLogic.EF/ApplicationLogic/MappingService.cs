using HomeAccounting.BusinesLogic.Contract.Dto;
using HomeAccounting.BusinesLogic.EF.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public static class MappingService
    {
        public static Account MapAccountModelToAccount(AccountModel accountModel)
        {
            Account account;
            switch (accountModel.Type)
            {
                case AccountType.Simple:
                    account = CreateSimpleAccountFromAccountModel(accountModel);
                    break;
                case AccountType.Deposit:
                    account = CreateDepositFromDepositModel((DepositModel)accountModel);
                    break;
                case AccountType.Property:
                    account = CreatePropertyFromPropertyModel((PropertyModel)accountModel);
                    break;
                case AccountType.Cash:
                    account = CreateCashFromCashModel((CashModel)accountModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Неизвестный тип счета {accountModel.Type}");
            }
            return account;
        }

        public static AccountModel MapAccountToAccountModel(Account account)
        {
            if (account == null)
            {
                return null;
            }
            if (account is Deposit)
            {
                return CreateDepositModelFromDeposit((Deposit)account);
            }
            else if (account is Cash)
            {
                return CreateCashModelFromCash((Cash)account);
            }
            else if (account is Property)
            {
                return CreatePropertyModelFromProperty((Property)account);
            }
            else
            {
                return CreateSimpleAccountModelFromAccount(account);
            }
        }

        public static Operation MapOperationModelToOperation(OperationModel operationModel)
        {
            return new Operation { 
                Id = operationModel.Id,
                FromAccount = MapAccountModelToAccount(operationModel.FromAccount),
                ToAccount = MapAccountModelToAccount(operationModel.ToAccount),
                Amount = operationModel.Amount,
                ExecutionDate = operationModel.ExecutionDate
            };
        }

        public static OperationModel MapOperationToOperationModel(Operation operation)
        {
            if(operation == null)
            {
                return null;
            }
            
            return new OperationModel
            {
                Id = operation.Id,
                FromAccount = MapAccountToAccountModel(operation.FromAccount),
                ToAccount = MapAccountToAccountModel(operation.ToAccount),
                Amount = operation.Amount,
                ExecutionDate = operation.ExecutionDate
            };
        }

        private static Deposit CreateDepositFromDepositModel(DepositModel depositModel)
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

        private static DepositModel CreateDepositModelFromDeposit(Deposit deposit)
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

        private static Account CreateSimpleAccountFromAccountModel(AccountModel accountModel)
        {
            return new Account
            {
                Id = accountModel.Id,
                Balance = accountModel.Balance,
                CreationDate = accountModel.CreationDate,
                Title = accountModel.Title
            };
        }

        private static AccountModel CreateSimpleAccountModelFromAccount(Account account)
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

        private static Property CreatePropertyFromPropertyModel(PropertyModel propertyModel)
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

        private static PropertyModel CreatePropertyModelFromProperty(Property property)
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

        private static Cash CreateCashFromCashModel(CashModel cashModel)
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

        private static CashModel CreateCashModelFromCash(Cash cash)
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
