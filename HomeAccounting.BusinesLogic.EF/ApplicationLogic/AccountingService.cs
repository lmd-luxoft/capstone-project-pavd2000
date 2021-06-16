using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HomeAccounting.BusinesLogic.EF.Domain;
using System.Threading.Tasks;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public class AccountingService : IAccountingService
    {
        IDbContextFactory<DomainContext> _contextFactory;
        public AccountingService(IDbContextFactory<DomainContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAccount(AccountModel accountModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = MappingService.MapAccountModelToAccount(accountModel);
                if (accountModel.Type == AccountType.Deposit)
                {
                    var deposit = (Deposit)account;
                    if (!string.IsNullOrWhiteSpace(deposit.Bank?.BIK))
                    {
                        var bank = await ctx.Banks.Where(x => x.BIK == deposit.Bank.BIK).FirstOrDefaultAsync();
                        if (bank != null)
                        {
                            deposit.Bank = bank;
                        }
                    }
                    await ctx.AddAsync(deposit);
                }
                else
                {
                    await ctx.AddAsync(account);
                }
                await ctx.SaveChangesAsync();
                accountModel.Id = account.Id;
            }
        }

        public async Task UpdateAccount(AccountModel accountModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = MappingService.MapAccountModelToAccount(accountModel);
                ctx.Attach(account);
                ctx.Update(account);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAccountById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id);
                if(account == null)
                {
                    throw new InvalidOperationException("Не найден счет для удаления!");
                }
                ctx.Remove(account);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<AccountModel> GetAccountById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var account = await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id);
                return MappingService.MapAccountToAccountModel(account);
            }
        }

        public async Task<List<AccountModel>> SelectByFilter(AccountModelFilter filter)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var accounts = ctx.Accounts.AsQueryable();
                accounts.OrderByDescending(x => x.Id);
                accounts.Skip((filter.Page - 1) * filter.OnPage).Take(filter.OnPage);
                return (await accounts.ToListAsync()).Select(x => MappingService.MapAccountToAccountModel(x)).ToList();
            }
        }
    }
}
