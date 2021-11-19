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


