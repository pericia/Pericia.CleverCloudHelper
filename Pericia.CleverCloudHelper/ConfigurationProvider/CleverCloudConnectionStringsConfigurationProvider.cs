using Microsoft.Extensions.Configuration;
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
            var data = new Dictionary<string, string>();

            if (CcEnvironment.PgsqlConnectionString != null)
            {
                data.Add(connectionStringsNames.PostgreSqlKey, CcEnvironment.PgsqlConnectionString);
            }

            if (CcEnvironment.MySqlConnectionString != null)
            {
                data.Add(connectionStringsNames.MySqlKey, CcEnvironment.MySqlConnectionString);
            }

            Data = Data;
        }
    }

}
