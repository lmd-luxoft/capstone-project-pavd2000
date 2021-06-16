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
        IDbContextFactory<DomainContext> _contextFactory;
        public OperationService(IDbContextFactory<DomainContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Create(OperationModel operationModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = MappingService.MapOperationModelToOperation(operationModel);
                ctx.Attach(operation.FromAccount);
                ctx.Attach(operation.ToAccount);
                ctx.Add(operation);
                ctx.SaveChanges();
                operationModel.Id = operation.Id;
            }
        }

        public void DeleteById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = new Operation { Id = id };
                ctx.Attach(operation);
                ctx.Remove(operation);
                ctx.SaveChanges();
            }
        }

        public OperationModel GetById(int id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = ctx.Operations.Include(x => x.FromAccount).Include(y => y.ToAccount).FirstOrDefault(z => z.Id == id);
                return MappingService.MapOperationToOperationModel(operation);
            }
        }

        public List<OperationModel> SelectByFilter(OperationModelFilter filter)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operations = ctx.Operations.Include(x => x.FromAccount).Include(y => y.ToAccount).AsQueryable();
                operations.OrderByDescending(x => x.Id);
                operations.Skip((filter.Page - 1) * filter.OnPage).Take(filter.OnPage);
                return operations.ToList().Select(x => MappingService.MapOperationToOperationModel(x)).ToList();
            }
        }

        public void Update(OperationModel operationModel)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var operation = MappingService.MapOperationModelToOperation(operationModel);
                ctx.Attach(operation);
                ctx.Update(operation);
                ctx.SaveChanges();
            }
        }


        private decimal GetAccountIncrese(int accountId)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return ctx.Operations.Where(x => x.ToAccount.Id == accountId).Select(x => x.Amount).Sum();

            }
        }

        private decimal GetAccountDecrese(int accountId)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return ctx.Operations.Where(x => x.FromAccount.Id == accountId).Select(x => x.Amount).Sum();
            }
        }

        public decimal AccountBalanceReport(int accountId)
        {
            var t1 = new Task<decimal>(() => { return GetAccountIncrese(accountId); });
            var t2 = new Task<decimal>(() => { return GetAccountDecrese(accountId); });
            var t3 = Task.WhenAll(t1, t2);
            t1.Start(); 
            t2.Start();
            t3.Wait();
            return t1.Result - t2.Result;
        }

    }
}
