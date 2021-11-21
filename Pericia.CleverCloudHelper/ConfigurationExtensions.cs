using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public static class ConfigurationExtensions
    {

        public static string MySqlConnectionString(this IConfiguration configuration, string name = "MySql")
            => FindConnectionString(configuration, name, CcEnvironment.MySqlConnectionString);

        public static string PostgreSqlConnectionString(this IConfiguration configuration, string name = "PostgreSql")
            => FindConnectionString(configuration, name, CcEnvironment.PgsqlConnectionString);

        private static string FindConnectionString(this IConfiguration configuration, string name, string? ccValue)
        {
            if (!string.IsNullOrEmpty(ccValue))
            {
                return ccValue;
            }

            return configuration.GetConnectionString(name);
        }

    }
}
