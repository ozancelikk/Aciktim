using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DependencyResolvers
{
    public class DataAccessModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection services)
        {
        }
    }
}
