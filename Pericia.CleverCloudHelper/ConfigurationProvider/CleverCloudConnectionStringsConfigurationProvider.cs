using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Pericia.CleverCloudHelper
{
    internal class CleverCloudConnectionStringsConfigurationProvider : ConfigurationProvider
    {
        private readonly ConnectionStringsOptions connectionStringsNames;

        public CleverCloudConnectionStringsConfigurationProvider(ConnectionStringsOptions connectionStringsNames)
        {
            this.connectionStringsNames = connectionStringsNames;
        }

        public override void Load()
        {
            if (CcEnvironment.PgsqlConnectionString != null)
            {
                Data.Add(connectionStringsNames.PostgreSqlKey, CcEnvironment.PgsqlConnectionString);
            }

            if (CcEnvironment.MySqlConnectionString != null)
            {
                Data.Add(connectionStringsNames.MySqlKey, CcEnvironment.MySqlConnectionString);
            }
        }
    }

}
