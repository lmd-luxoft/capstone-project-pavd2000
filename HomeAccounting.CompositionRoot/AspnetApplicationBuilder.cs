//using HomeAccounting.BusinesLogic;
//using HomeAccounting.BusinesLogic.Contract;
//using HomeAccounting.DataSource;
//using HomeAccounting.DataSource.Contract;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace HomeAccounting.CompositionRoot
//{
//    public class AspnetApplicationBuilder : AbstractApplicationBuilder
//    {

//        public AspnetApplicationBuilder(IServiceCollection service): base (service)
//        {

//        }
//        protected override void RegisterBusinesLogic()
//        {
//            _services.AddTransient<IAccounting, AccountingService>();
//        }

//        protected override void RegisterDataSource()
//        {
//            _services.AddTransient<IRepository, RepositoryBaseSql>();
//        }

//        protected override void RegisterInfrastructure()
//        {

//        }
//    }
//}
