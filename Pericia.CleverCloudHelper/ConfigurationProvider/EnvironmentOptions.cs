﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public class EnvironmentOptions
    {
        public string CcInstanceNumberKey { get; set; } = "CleverCloud:InstanceNumber";
        public string CcInstanceTypeKey { get; set; } = "CleverCloud:InstanceType";
        public string CcInstanceIdKey { get; set; } = "CleverCloud:InstanceId";
        public string CcPrettyInstanceNameKey { get; set; } = "CleverCloud:PrettyInstanceName";
        public string CcAppIdKey { get; set; } = "CleverCloud:AppId";
        public string CcAppHomePathKey { get; set; } = "CleverCloud:AppHomePath";
        public string CcDeploymentIdKey { get; set; } = "CleverCloud:DeploymentId";
        public string CcCommitIdKey { get; set; } = "CleverCloud:CommitId";

        public string PgsqlHostKey { get; set; } = "PostgreSql:Host";
        public string PgsqlDbKey { get; set; } = "PostgreSql:Database";
        public string PgsqlUserKey { get; set; } = "PostgreSql:User";
        public string PgsqlPasswordKey { get; set; } = "PostgreSql:Password";
        public string PgsqlPortKey { get; set; } = "PostgreSql:Port";
        public string PgsqlConnStringKey { get; set; } = "ConnectionStrings:PostgreSql";

        public string MySqlHostKey { get; set; } = "MySql:Host";
        public string MySqlDbKey { get; set; } = "MySql:Database";
        public string MySqlUserKey { get; set; } = "MySql:User";
        public string MySqlPasswordKey { get; set; } = "MySql:Password";
        public string MySqlPortKey { get; set; } = "MySql:Port";
        public string MySqlConnStringKey { get; set; } = "ConnectionStrings:MySql";

        public string MongodbHostKey { get; set; } = "MongoDb:Host";
        public string MongodbDbKey { get; set; } = "MongoDb:Database";
        public string MongodbUserKey { get; set; } = "MongoDb:User";
        public string MongodbPasswordKey { get; set; } = "MongoDb:Password";
        public string MongodbPortKey { get; set; } = "MongoDb:Port";
        public string MongodbUriKey { get; set; } = "ConnectionStrings:MongoDb";

        public string RedisHostKey { get; set; } = "Redis:Host";
        public string RedisPortKey { get; set; } = "Redis:Port";
        public string RedisPasswordtKey { get; set; } = "Redis:Password";


        public string ElasticsearchUriKey { get; set; } = "Elastic:Uri";
        public string ElasticsearchHostKey { get; set; } = "Elastic:Host";
        public string ElasticsearchUserKey { get; set; } = "Elastic:User";
        public string ElasticsearchPasswordKey { get; set; } = "Elastic:Password";

        public string KibanaHostKey { get; set; } = "Kibana:Host";
        public string KibanaUserKey { get; set; } = "Kibana:User";
        public string KibanaPasswordKey { get; set; } = "Kibana:Password";

        public string ApmHostKey { get; set; } = "ElasticApm:ServerUrl";
        public string ApmAuthTokenKey { get; set; } = "ElasticApm:SecretToken";
        public string ApmUserKey { get; set; } = "ElasticApm:User";
        public string ApmPasswordKey { get; set; } = "ElasticApm:Password";

        public string PulsarBinaryPortKey { get; set; } = "Pulsar:BinaryPort";
        public string PulsarBinaryUrlKey { get; set; } = "Pulsar:BinaryUrl";
        public string PulsarHostNameKey { get; set; } = "Pulsar:HostName";
        public string PulsarHttpPortKey { get; set; } = "Pulsar:HttpPort";
        public string PulsarHttpUrlKey { get; set; } = "Pulsar:HttpUrl";
        public string PulsarNamespaceKey { get; set; } = "Pulsar:Namespace";
        public string PulsarTenantKey { get; set; } = "Pulsar:Tenant";
        public string PulsarTokenKey { get; set; } = "Pulsar:Token";

        public string CellarHostKey { get; set; } = "Cellar:Host";
        public string CellarKeyIdKey { get; set; } = "Cellar:KeyId";
        public string CellarKeySecretKey { get; set; } = "Cellar:KeySecret";

        public string BucketHostKey { get; set; } = "Bucket:Host";

    }
}
