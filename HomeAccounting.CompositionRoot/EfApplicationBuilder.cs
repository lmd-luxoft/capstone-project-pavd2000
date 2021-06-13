using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.EF.ApplicationLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.CompositionRoot
{

    public class EfApplicationBuilder : AbstractApplicationBuilder
    {

        public EfApplicationBuilder(IServiceCollection service) : base(service)
        {

        }
        protected override void RegisterBusinesLogic()
        {
            _services.AddTransient<IAccountingService, AccountingService>();
            _services.AddTransient<IOperationService, OperationService>();
        }

        protected override void RegisterDataSource()
        {
            _services.AddDbContextFactory<DomainContext>();
        }

        protected override void RegisterInfrastructure()
        {

        }
    }

}
