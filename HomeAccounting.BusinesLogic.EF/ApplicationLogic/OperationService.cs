using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.Contract.Dto;
using HomeAccounting.BusinesLogic.EF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public class OperationService : IOperationService
    {
        private readonly IDbContextFactory<DomainContext> _contextFactory;
        private readonly ISendEmailService _sendEmailService;

        public OperationService(IDbContextFactory<DomainContext> contextFactory, ISendEmailService sendEmailService)
        {
            _contextFactory = contextFactory;
            _sendEmailService = sendEmailService;
        }

        public async Task Create(OperationModel operationModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = MappingService.MapOperationModelToOperation(operationModel);
                ctx.Attach(operation.FromAccount);
                ctx.Attach(operation.ToAccount);
                await ctx.AddAsync(operation);
                await ctx.SaveChangesAsync();
                operationModel.Id = operation.Id;
            }
            _ = _sendEmailService.SendEmail("bill@microsoft.com", $"Создана операция с Id {operationModel.Id}");
        }

        public async Task DeleteById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = new Operation { Id = id };
                ctx.Attach(operation);
                ctx.Remove(operation);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<OperationModel> GetById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = await ctx.Operations.Include(x => x.FromAccount).Include(y => y.ToAccount).FirstOrDefaultAsync(z => z.Id == id);
                return MappingService.MapOperationToOperationModel(operation);
            }
        }

        public async Task<List<OperationModel>> SelectByFilter(OperationModelFilter filter)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operations = ctx.Operations.Include(x => x.FromAccount).Include(y => y.ToAccount).AsQueryable();
                operations.OrderByDescending(x => x.Id);
                operations.Skip((filter.Page - 1) * filter.OnPage).Take(filter.OnPage);
                return (await operations.ToListAsync()).Select(x => MappingService.MapOperationToOperationModel(x)).ToList();
            }
        }

        public async Task Update(OperationModel operationModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = MappingService.MapOperationModelToOperation(operationModel);
                ctx.Attach(operation);
                ctx.Update(operation);
                await ctx.SaveChangesAsync();
            }
        }


        private async Task<decimal> GetAccountIncrese(int accountId)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return await ctx.Operations.Where(x => x.ToAccount.Id == accountId).Select(x => x.Amount).SumAsync();
            }
        }

        private async Task<decimal> GetAccountDecrese(int accountId)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return await ctx.Operations.Where(x => x.FromAccount.Id == accountId).Select(x => x.Amount).SumAsync();
            }
        }

        public async Task<decimal> AccountBalanceReport(int accountId)
        { 
            var result = await Task.WhenAll(GetAccountIncrese(accountId), GetAccountDecrese(accountId));
            return result[0] - result[1];
        }

    }
}
