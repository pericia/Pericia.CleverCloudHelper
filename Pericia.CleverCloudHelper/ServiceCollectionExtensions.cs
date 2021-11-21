using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection ConfigureCcProxy(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.All;

                foreach (var ip in CcEnvironment.ReverseProxyIps)
                {
                    options.KnownProxies.Add(IPAddress.Parse(ip));
                }
            });

            return services;
        }

    }
}
