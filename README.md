# Pericia.CleverCloudHelper

Un peu d'aide pour configurer et déployer son application ASP.NET Core dans [Clever Cloud](https://www.clever-cloud.com/)

## Chargement des ConnectionStrings

Lorsqu'on déploie une application liée à une base de données, les informations de connexion sont accessibles sous forme de variables d'environnement.

Pour les utiliser plus facilement, cette librairie les renvoie sous forme de ConnectionString :

    CcEnvironment.MySqlConnectionString
    CcEnvironment.PgsqlConnectionString

Afin d'accéder à ces connection strings depuis la configuration, vous pouvez appeler `builder.AddCcConnectionStrings()` dans `ConfigureAppConfiguration` :

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true)
                            .AddCcEnvironment()
                            .AddEnvironmentVariables();
                
                if (ctx.HostingEnvironment.IsDevelopment())
                {
                    builder.AddUserSecrets<Startup>();
                }
            })
            .UseStartup<Startup>()
            .Build();


Afin de pouvoir utiliser des valeurs différentes sur son poste de développement, ajoutez les chaines de connexion dans votre fichier `appsettings.Development.json` ou vos user secrets

    {
        "ConnectionStrings": {
            "PostgreSql": "Host=localhost;Port=5432;Database=dbName;Username=usr;Password=pwd",
            "MySql": "Server=localhost;Port=3306;Database=dbName;Uid=usr;Pwd=pwd"
        }
    }

Ainsi, vos chaines de connexion sont accessibles depuis `IConfiguration` :

    configuration.GetConnectionString("PostgreSql");
    configuration.GetConnectionString("MySql");


## Autorisation du reverse-proxy Clever Cloud

Une fois déployée dans Clever Cloud, votre application sera derrière un load-balancer, et il vous faudra donc [la configurer en conséquence](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer).

Ajoutez l'appel à la méthode `services.ConfigureCcProxy();` dans `ConfigureServices`, et `app.UseForwardedHeaders();` au début de `Configure` :


    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureCcProxy();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseForwardedHeaders();

        app.Run(async (context) =>
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Request Url: " + context.Request.GetDisplayUrl());
        });
    }

## Variables d'environnement

[Les principales variables d'environnement](https://www.clever-cloud.com/doc/reference/reference-environment-variables/) sont accessibles depuis la classe statique `CcEnvironment`,
ou depuis `IConfiguration` (si vous avez appelé la méthode `builder.AddCcEnvironment()`).



### Common

| Variable d'environnement | Propriété          | Clé configuration              | Type     |
| ------------------------ | ------------------ | ------------------------------ | -------- |
| INSTANCE_NUMBER          | InstanceNumber     | CleverCloud:InstanceNumber     | int?     |
| INSTANCE_TYPE            | InstanceType       | CleverCloud:InstanceType       | string   |
| INSTANCE_ID              | InstanceId         | CleverCloud:InstanceId         | string   |
| CC_PRETTY_INSTANCE_NAME  | PrettyInstanceName | CleverCloud:PrettyInstanceName | string   |
| APP_ID                   | AppId              | CleverCloud:AppId              | string   |
| APP_HOME                 | AppHomePath        | CleverCloud:AppHomePath        | string   |
| CC_DEPLOYMENT_ID         | DeploymentId       | CleverCloud:DeploymentId       | string   |
| COMMIT_ID                | CommitId           | CleverCloud:CommitId           | string   |
| CC_REVERSE_PROXY_IPS     | ReverseProxyIps    |                                | string[] |

### .NET

| Variable d'environnement | Propriété          | Type   |
| ------------------------ | ------------------ | ------ |
| CC_DOTNET_VERSION        | DotnetVersion      | string |
| CC_DOTNET_PROJ           | DotnetProj         | string |
| CC_DOTNET_TFM            | DotnetTfm          | string |
| CC_DOTNET_PROFILE        | DotnetProfile      | string |
| CC_RUN_COMMAND           | RunCommand         | string |

### Addons

| Variable d'environnement  | Propriété             | Clé configuration            | Type   |
| ------------------------- | --------------------- | ---------------------------- | ------ |
| POSTGRESQL_ADDON_HOST     | PgsqlHost             | PostgreSql:Host              | string |
| POSTGRESQL_ADDON_PORT     | PgsqlPort             | PostgreSql:Port              | string |
| POSTGRESQL_ADDON_DB       | PgsqlDatabase         | PostgreSql:Database          | string |
| POSTGRESQL_ADDON_USER     | PgsqlUser             | PostgreSql:User              | string |
| POSTGRESQL_ADDON_PASSWORD | PgsqlPassword         | PostgreSql:Password          | string |
|                           | PgsqlConnectionString | ConnectionStrings:PostgreSql | string |
| MYSQL_ADDON_HOST          | MysqlHost             | MySql:Host                   | string |
| MYSQL_ADDON_PORT          | MysqlPort             | MySql:Port                   | string |
| MYSQL_ADDON_DB            | MysqlDatabase         | MySql:Database               | string |
| MYSQL_ADDON_USER          | MysqlUser             | MySql:User                   | string |
| MYSQL_ADDON_PASSWORD      | MysqlPassword         | MySql:Password               | string |
|                           | MySqlConnectionString | ConnectionStrings:MySql      | string |
| MONGODB_ADDON_DB          | MongodbDb             | MongoDb:Database             | string |
| MONGODB_ADDON_USER        | MongodbUser           | MongoDb:User                 | string |
| MONGODB_ADDON_PASSWORD    | MongodbPassword       | MongoDb:Password             | string |
| REDIS_HOST                | RedisHost             | Redis:Host                   | string |
| REDIS_PORT                | RedisPort             | Redis:Port                   | string |
| REDIS_PASSWORD            | RedisPassword         | Redis:Password               | string |
| ES_ADDON_URI              | ElasticsearchUri      | Elastic:Uri                  | string |
| ES_ADDON_HOST             | ElasticsearchHost     | Elastic:Host                 | string |
| ES_ADDON_USER             | ElasticsearchUser     | Elastic:User                 | string |
| ES_ADDON_PASSWORD         | ElasticsearchPassword | Elastic:Password             | string |
| ES_ADDON_KIBANA_HOST      | KibanaHost            | Kibana:Host                  | string |
| ES_ADDON_KIBANA_USER      | KibanaUser            | Kibana:User                  | string |
| ES_ADDON_KIBANA_PASSWORD  | KibanaPassword        | Kibana:Password              | string |
| ES_ADDON_APM_HOST         | ApmHost               | ElasticApm:ServerUrl         | string |
| ES_ADDON_APM_AUTH_TOKEN   | ApmAuthToken          | ElasticApm:SecretToken       | string |
| ES_ADDON_APM_USER         | ApmUser               | ElasticApm:User              | string |
| ES_ADDON_APM_PASSWORD     | ApmPassword           | ElasticApm:Password          | string |
| CELLAR_ADDON_HOST         | CellarHost            | Cellar:Host                  | string |
| CELLAR_ADDON_KEY_ID       | CellarKeyId           | Cellar:KeyId                 | string |
| CELLAR_ADDON_KEY_SECRET   | CellarKeySecret       | Cellar:KeySecret             | string |
| BUCKET_HOST               | BucketHost            | Bucket:Host                  | string |

