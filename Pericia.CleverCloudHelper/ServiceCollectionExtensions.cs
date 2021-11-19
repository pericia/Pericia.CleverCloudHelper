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
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                var proxyIps = Environment.GetEnvironmentVariable("CC_REVERSE_PROXY_IPS");
                if (!string.IsNullOrEmpty(proxyIps))
                {
                    var ips = proxyIps.Split(',');
                    foreach (var ip in ips)
                    {
                        options.KnownProxies.Add(IPAddress.Parse(ip));
                    }
                }
            });

            return services;
        }

    }
}
