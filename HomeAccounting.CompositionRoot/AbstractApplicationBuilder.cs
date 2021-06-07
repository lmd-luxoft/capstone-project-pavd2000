using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.CompositionRoot
{
    public abstract class AbstractApplicationBuilder
    {
        protected readonly IServiceCollection _services;
        protected abstract void RegisterBusinesLogic();
        protected abstract void RegisterDataSource();
        protected abstract void RegisterInfrastructure();

        public AbstractApplicationBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public void Buid()
        {
            RegisterInfrastructure();
            RegisterDataSource();
            RegisterBusinesLogic();
        }
    }
}
