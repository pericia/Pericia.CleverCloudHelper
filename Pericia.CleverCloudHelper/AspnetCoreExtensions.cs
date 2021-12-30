using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public static class AspnetCoreExtensions
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

        public static IConfigurationBuilder AddCcEnvironment(this IConfigurationBuilder builder, Action<EnvironmentOptions>? configureEnvironment = null)
        {
            var environmentOptions = new EnvironmentOptions();
            if (configureEnvironment != null)
            {
                configureEnvironment(environmentOptions);
            }

            builder.Add(new CleverCloudEnvironmentConfigurationSource(environmentOptions));
            return builder;
        }
    }
}
