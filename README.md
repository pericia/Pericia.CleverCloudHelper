# Pericia.CleverCloudHelper

Un peu d'aide pour configurer et déployer son application ASP.NET Core dans [Clever Cloud](https://www.clever-cloud.com/)

## Autorisation du reverse-proxy Clever Cloud

Une fois déployée dans Clever Cloud, votre application sera derrière un load-balancer, et il vous faudra donc [la configurer en conséquence](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer).

Ajoutez l'appel à la méthode `services.ConfigureCcProxy();` dans `ConfigureServices`, et `app.UseForwardedHeaders();` au début de `Configure`


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

            await context.Response.WriteAsync($"Request Url: {context.Request.GetDisplayUrl()}{Environment.NewLine}");           
        });
    }

## Chargement des ConnectionStrings

Lorsqu'on déploie une application liée à une base de données, les informations de connexion sont accessibles sous forme de variables d'environnement.

Pour les utiliser plus facilement, cette librairie les renvoie sous forme de ConnectionString :

    CcConnectionStrings.MySql
    CcConnectionStrings.PostgreSql

Afin de pouvoir utiliser des valeurs différentes sur son poste de développement, ajoutez les chaines de connexion dans votre fichier `appsettings.Development.json` ou vos user secrets

    {
      "ConnectionStrings": {
        "PostgreSql": "Host=localhost;Port=5432;Database=dbName;Username=usr;Password=pwd",
        "MySql": "Server=localhost;Port=3306;Database=dbName;Uid=usr;Pwd=pwd"
      }
    }


Vous pouvez utiliser ensuite les méthodes d'extensions suivantes :

    Configuration.MySqlConnectionString();
    Configuration.PostgreSqlConnectionString();

Ces méthodes vont d'abord vérifier si la chaine de connexion est définie dans la configuration, et si elle est absente va renvoyer la valeur Clever Cloud. Aussi il est important
de ne pas définir vos chaines de connexion dans le `appsettings.json` principal.