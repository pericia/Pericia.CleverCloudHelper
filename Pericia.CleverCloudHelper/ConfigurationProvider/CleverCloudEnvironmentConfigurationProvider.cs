using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Pericia.CleverCloudHelper
{
    internal class CleverCloudEnvironmentConfigurationProvider : ConfigurationProvider
    {
        private readonly EnvironmentOptions environmentOptions;

        public CleverCloudEnvironmentConfigurationProvider(EnvironmentOptions environmentOptions)
        {
            this.environmentOptions = environmentOptions;
        }

        public override void Load()
        {
            AddValue(environmentOptions.CcInstanceNumberKey, CcEnvironment.InstanceNumber?.ToString());
            AddValue(environmentOptions.CcInstanceTypeKey, CcEnvironment.InstanceType);
            AddValue(environmentOptions.CcInstanceIdKey, CcEnvironment.InstanceId);
            AddValue(environmentOptions.CcPrettyInstanceNameKey, CcEnvironment.PrettyInstanceName);
            AddValue(environmentOptions.CcAppIdKey, CcEnvironment.AppId);
            AddValue(environmentOptions.CcAppHomePathKey, CcEnvironment.AppHomePath);
            AddValue(environmentOptions.CcDeploymentIdKey, CcEnvironment.DeploymentId);
            AddValue(environmentOptions.CcCommitIdKey, CcEnvironment.CommitId);

            AddValue(environmentOptions.PgsqlHostKey, CcEnvironment.PgsqlHost);
            AddValue(environmentOptions.PgsqlDbKey, CcEnvironment.PgsqlDatabase);
            AddValue(environmentOptions.PgsqlUserKey, CcEnvironment.PgsqlUser);
            AddValue(environmentOptions.PgsqlPasswordKey, CcEnvironment.PgsqlPassword);
            AddValue(environmentOptions.PgsqlPortKey, CcEnvironment.PgsqlPort);
            AddValue(environmentOptions.PgsqlConnStringKey, CcEnvironment.PgsqlConnectionString);

            AddValue(environmentOptions.MySqlHostKey, CcEnvironment.MysqlHost);
            AddValue(environmentOptions.MySqlDbKey, CcEnvironment.MysqlDatabase);
            AddValue(environmentOptions.MySqlUserKey, CcEnvironment.MysqlUser);
            AddValue(environmentOptions.MySqlPasswordKey, CcEnvironment.MysqlPassword);
            AddValue(environmentOptions.MySqlPortKey, CcEnvironment.MysqlPort);
            AddValue(environmentOptions.MySqlConnStringKey, CcEnvironment.MySqlConnectionString);

            AddValue(environmentOptions.MongodbDbKey, CcEnvironment.MongodbDb);
            AddValue(environmentOptions.MongodbUserKey, CcEnvironment.MongodbUser);
            AddValue(environmentOptions.MongodbPasswordKey, CcEnvironment.MongodbPassword);

            AddValue(environmentOptions.RedisHostKey, CcEnvironment.RedisHost);
            AddValue(environmentOptions.RedisPortKey, CcEnvironment.RedisPort);
            AddValue(environmentOptions.RedisPasswordtKey, CcEnvironment.RedisPassword);
        }

        private void AddValue(string key, string? value)
        {
            if (!string.IsNullOrEmpty(key) && value != null)
            {
                Data.Add(key, value);
            }
        }
    }

}
