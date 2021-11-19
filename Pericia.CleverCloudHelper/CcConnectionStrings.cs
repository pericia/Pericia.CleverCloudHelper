using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public static class CcConnectionStrings
    {
        public static string MySql
        {
            get
            {
                var server = Environment.GetEnvironmentVariable("MYSQL_ADDON_HOST");
                var port = Environment.GetEnvironmentVariable("MYSQL_ADDON_PORT");
                var database = Environment.GetEnvironmentVariable("MYSQL_ADDON_DB");
                var uid = Environment.GetEnvironmentVariable("MYSQL_ADDON_USER");
                var pwd = Environment.GetEnvironmentVariable("MYSQL_ADDON_PASSWORD");

                return $"Server={server};Port={port};Database={database};Uid={uid};Pwd={pwd};";
            }
        }

        public static string PostgreSql
        {
            get
            {
                var server = Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_HOST");
                var port = Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_PORT");
                var database = Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_DB");
                var userid = Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_USER");
                var password = Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_PASSWORD");

                return $"Server={server};Port={port};Database={database};User ID={userid};Password={password};";
            }
        }

        public static string MySqlConnectionString(this IConfiguration configuration, string name = "MySql")
            => FindConnectionString(configuration, name, MySql);

        public static string PostgreSqlConnectionString(this IConfiguration configuration, string name = "PostgreSql")
            => FindConnectionString(configuration, name, PostgreSql);

        private static string FindConnectionString(this IConfiguration configuration, string name, string ccValue)
        {
            var configValue = configuration.GetConnectionString(name);
            if (!string.IsNullOrEmpty(configValue))
            {
                return configValue;
            }

            return ccValue;
        }
    }
}
