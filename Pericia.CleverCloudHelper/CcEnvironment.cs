using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public static class CcEnvironment
    {
        // App and Instance info

        public static int? InstanceNumber => GetNullableIntValue("INSTANCE_NUMBER");
        public static string? InstanceType => Environment.GetEnvironmentVariable("INSTANCE_TYPE");
        public static string? InstanceId => Environment.GetEnvironmentVariable("INSTANCE_ID");
        public static string? PrettyInstanceName => Environment.GetEnvironmentVariable("CC_PRETTY_INSTANCE_NAME");
        public static string? AppId => Environment.GetEnvironmentVariable("APP_ID");
        public static string? AppHomePath => Environment.GetEnvironmentVariable("APP_HOME");
        public static string? DeploymentId => Environment.GetEnvironmentVariable("CC_DEPLOYMENT_ID");
        public static string? CommitId => Environment.GetEnvironmentVariable("COMMIT_ID");
        public static string[] ReverseProxyIps => Environment.GetEnvironmentVariable("CC_REVERSE_PROXY_IPS")?.Split(',') ?? new string[0];


        // .NET

        public static string? DotnetVersion => Environment.GetEnvironmentVariable("CC_DOTNET_VERSION");
        public static string? DotnetProj => Environment.GetEnvironmentVariable("CC_DOTNET_PROJ");
        public static string? DotnetTfm => Environment.GetEnvironmentVariable("CC_DOTNET_TFM");
        public static string? DotnetProfile => Environment.GetEnvironmentVariable("CC_DOTNET_PROFILE");
        public static string? RunCommand => Environment.GetEnvironmentVariable("CC_RUN_COMMAND");


        // MySQL

        public static string? MysqlHost => Environment.GetEnvironmentVariable("MYSQL_ADDON_HOST");
        public static string? MysqlPort => Environment.GetEnvironmentVariable("MYSQL_ADDON_PORT");
        public static string? MysqlDatabase => Environment.GetEnvironmentVariable("MYSQL_ADDON_DB");
        public static string? MysqlUser => Environment.GetEnvironmentVariable("MYSQL_ADDON_USER");
        public static string? MysqlPassword => Environment.GetEnvironmentVariable("MYSQL_ADDON_PASSWORD");

        public static string? MySqlConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(MysqlHost))
                {
                    return null;
                }

                return $"Server={MysqlHost};Port={MysqlPort};Database={MysqlDatabase};Uid={MysqlUser};Pwd={MysqlPassword};";
            }
        }

        // PostgresSql

        public static string? PgsqlHost => Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_HOST");
        public static string? PgsqlPort => Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_PORT");
        public static string? PgsqlDatabase => Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_DB");
        public static string? PgsqlUser => Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_USER");
        public static string? PgsqlPassword => Environment.GetEnvironmentVariable("POSTGRESQL_ADDON_PASSWORD");

        public static string? PgsqlConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(PgsqlHost))
                {
                    return null;
                }

                return $"Server={PgsqlHost};Port={PgsqlPort};Database={PgsqlDatabase};User ID={PgsqlUser};Password={PgsqlPassword};";
            }
        }

        // MongoDB
        public static string? MongodbHost => Environment.GetEnvironmentVariable("MONGODB_ADDON_HOST");
        public static string? MongodbDb => Environment.GetEnvironmentVariable("MONGODB_ADDON_DB");
        public static string? MongodbUser => Environment.GetEnvironmentVariable("MONGODB_ADDON_USER");
        public static string? MongodbPassword => Environment.GetEnvironmentVariable("MONGODB_ADDON_PASSWORD");
        public static string? MongodbPort => Environment.GetEnvironmentVariable("MONGODB_ADDON_PORT");
        public static string? MongodbUri => Environment.GetEnvironmentVariable("MONGODB_ADDON_URI");


        // Redis
        public static string? RedisHost => Environment.GetEnvironmentVariable("REDIS_HOST");
        public static string? RedisPort => Environment.GetEnvironmentVariable("REDIS_PORT");
        public static string? RedisPassword => Environment.GetEnvironmentVariable("REDIS_PASSWORD");

        // ElasticSearch

        public static string? ElasticsearchUri => Environment.GetEnvironmentVariable("ES_ADDON_URI");
        public static string? ElasticsearchHost => Environment.GetEnvironmentVariable("ES_ADDON_HOST");
        public static string? ElasticsearchUser => Environment.GetEnvironmentVariable("ES_ADDON_USER");
        public static string? ElasticsearchPassword => Environment.GetEnvironmentVariable("ES_ADDON_PASSWORD");

        public static string? KibanaHost => Environment.GetEnvironmentVariable("ES_ADDON_KIBANA_HOST");
        public static string? KibanaUser => Environment.GetEnvironmentVariable("ES_ADDON_KIBANA_USER");
        public static string? KibanaPassword => Environment.GetEnvironmentVariable("ES_ADDON_KIBANA_PASSWORD");

        public static string? ApmHost => Environment.GetEnvironmentVariable("ES_ADDON_APM_HOST");
        public static string? ApmAuthToken => Environment.GetEnvironmentVariable("ES_ADDON_APM_AUTH_TOKEN");
        public static string? ApmUser => Environment.GetEnvironmentVariable("ES_ADDON_APM_USER");
        public static string? ApmPassword => Environment.GetEnvironmentVariable("ES_ADDON_APM_PASSWORD");

        // Pulsar
        public static int? PulsarBinaryPort => GetNullableIntValue("ADDON_PULSAR_BINARY_PORT");      
        public static string? PulsarBinaryUrl => Environment.GetEnvironmentVariable("ADDON_PULSAR_BINARY_URL");
        public static string? PulsarHostName => Environment.GetEnvironmentVariable("ADDON_PULSAR_HOSTNAME");
        public static int? PulsarHttpPort => GetNullableIntValue("ADDON_PULSAR_HTTP_PORT");
        public static string? PulsarHttpUrl => Environment.GetEnvironmentVariable("ADDON_PULSAR_HTTP_URL");
        public static string? PulsarNamespace => Environment.GetEnvironmentVariable("ADDON_PULSAR_NAMESPACE");
        public static string? PulsarTenant => Environment.GetEnvironmentVariable("ADDON_PULSAR_TENANT");
        public static string? PulsarToken => Environment.GetEnvironmentVariable("ADDON_PULSAR_TOKEN");


        // Cellar
        public static string? CellarHost => Environment.GetEnvironmentVariable("CELLAR_ADDON_HOST");
        public static string? CellarKeyId => Environment.GetEnvironmentVariable("CELLAR_ADDON_KEY_ID");
        public static string? CellarKeySecret => Environment.GetEnvironmentVariable("CELLAR_ADDON_KEY_SECRET");

        // Bucket
        public static string? BucketHost => Environment.GetEnvironmentVariable("BUCKET_HOST");

        private static int? GetNullableIntValue(string variable)
        {
            var number = Environment.GetEnvironmentVariable(variable);
            if (!string.IsNullOrEmpty(number) && int.TryParse(number, out int result))
            {
                return result;
            }

            return null;
        }
    }

}
