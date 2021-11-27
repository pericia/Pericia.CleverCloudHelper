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
                            .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true);
                            .AddCcConnectionStrings()
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

[Les principales variables d'environnement](https://www.clever-cloud.com/doc/reference/reference-environment-variables/) sont accessibles depuis la classe statique `CcEnvironment`.

### Common

| Variable d'environnement | Propriété          | Type     | Notes |
| ------------------------ | ------------------ | -------- | ----- |
| INSTANCE_NUMBER          | InstanceNumber     | int      | -1 si la variable d'environnement n'est pas définie |
| INSTANCE_TYPE            | InstanceType       | string   | |
| INSTANCE_ID              | InstanceId         | string   | |
| CC_PRETTY_INSTANCE_NAME  | PrettyInstanceName | string   | |
| APP_ID                   | AppId              | string   | |
| APP_HOME                 | AppHomePath        | string   | |
| CC_DEPLOYMENT_ID         | DeploymentId       | string   | |
| COMMIT_ID                | CommitId           | string   | |
| CC_REVERSE_PROXY_IPS     | ReverseProxyIps    | string[] | |

### .NET

| Variable d'environnement | Propriété          | Type   | Notes |
| ------------------------ | ------------------ | ------ | ----- |
| CC_DOTNET_VERSION        | DotnetVersion      | string | |
| CC_DOTNET_PROJ           | DotnetProj         | string | |
| CC_DOTNET_TFM            | DotnetTfm          | string | |
| CC_DOTNET_PROFILE        | DotnetProfile      | string | |
| CC_RUN_COMMAND           | RunCommand         | string | |
