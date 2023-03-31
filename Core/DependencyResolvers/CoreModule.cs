using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)          // for DI
        {
        }
    }
}
