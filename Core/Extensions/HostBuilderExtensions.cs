using Core.Utilities.IoC;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHost AddHostBuilder(this IHostBuilder hostBuilder)
        {
            return ServiceTool.CreateForAutofac(hostBuilder);
        }
    }
}
