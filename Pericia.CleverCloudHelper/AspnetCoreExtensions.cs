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

        public static IConfigurationBuilder AddCcConnectionStrings(this IConfigurationBuilder builder)
            => AddCcConnectionStrings(builder, null!);

        public static IConfigurationBuilder AddCcConnectionStrings(this IConfigurationBuilder builder, Action<ConnectionStringsOptions> configureConnectionStrings)
        {
            var connectionStringsNames = new ConnectionStringsOptions();
            if (configureConnectionStrings != null)
            {
                configureConnectionStrings(connectionStringsNames);
            }

            builder.Add(new CleverCloudConnectionStringsConfigurationSource(connectionStringsNames));
            return builder;
        }
    }
}
