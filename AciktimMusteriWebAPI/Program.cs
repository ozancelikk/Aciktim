using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using DataAccess.DependencyResolvers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AciktimMusteriWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).AddHostBuilder();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseUrls("https://*:5001", "http://*:5000");
               //webBuilder.UseKestrel().UseStartup<Startup>();

           })
           .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>(builder =>
               {

                   builder.RegisterModule(new AutofacBusinessModule());
                   builder.RegisterModule(new AutoFacCoreModule());
                   builder.RegisterModule(new AutoFacDataAccessModule());


               })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
