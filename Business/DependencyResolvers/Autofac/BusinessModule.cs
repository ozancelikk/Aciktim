using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Autofac.DependencyResolvers
{
    public class BusinessModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)          // for DI
        {
        }
    }
}
