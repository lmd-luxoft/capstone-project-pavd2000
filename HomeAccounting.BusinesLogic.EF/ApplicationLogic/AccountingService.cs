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
                var account = MappingService.MapAccountModelToAccount(accountModel);
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

        public void UpdateAccount(AccountModel accountModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = MappingService.MapAccountModelToAccount(accountModel);
                ctx.Attach(account);
                ctx.Update(account);
                ctx.SaveChanges();
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
                return MappingService.MapAccountToAccountModel(account);
            }
        }

        public List<AccountModel> SelectByFilter(AccountModelFilter filter)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var accounts = ctx.Accounts.AsQueryable();
                accounts.OrderByDescending(x => x.Id);
                accounts.Skip((filter.Page - 1) * filter.OnPage).Take(filter.OnPage);
                return accounts.ToList().Select(x => MappingService.MapAccountToAccountModel(x)).ToList();
            }
        }
    }
}
