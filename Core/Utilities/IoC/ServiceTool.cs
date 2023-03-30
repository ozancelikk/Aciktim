using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Services { get; private set; }
        public static IHost Host;
        public static IServiceCollection CreateForMicrosoftDependencies(IServiceCollection services)
        {

            Services = services;
            ServiceProvider = services.BuildServiceProvider();


            return services;
        }

        public static IHost CreateForAutofac(IHostBuilder hostBuilder)
        {

            Host = hostBuilder.Build();

            return Host;
        }
        public static List<T> GetServiceList<T>(int serviceNumber)
        {
            List<T> services = new List<T>();
            for (int i = 0; i < serviceNumber; i++)
            {
                services.Add(Host.Services.GetService<T>());
            }
            return services;

        }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
