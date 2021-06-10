using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.CompositionRoot
{
    public class AspnetApplicationBuilder : AbstractApplicationBuilder
    {

        public AspnetApplicationBuilder(IServiceCollection service): base (service)
        {

        }
        protected override void RegisterBusinesLogic()
        {
            throw new NotImplementedException();
        }

        protected override void RegisterDataSource()
        {
            throw new NotImplementedException();
        }

        protected override void RegisterInfrastructure()
        {
            throw new NotImplementedException();
        }
    }
}
