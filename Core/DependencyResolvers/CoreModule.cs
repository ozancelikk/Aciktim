using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)          // for DI
        {
        }
    }
}
