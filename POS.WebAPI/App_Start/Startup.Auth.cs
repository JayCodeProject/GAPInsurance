using POS.WebAPI.Business;
using POS.WebAPI.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Unity;

[assembly: OwinStartup(typeof(POS.WebAPI.App_Start.Startup))]

namespace POS.WebAPI.App_Start
{
    public class Startup
    {
        public static UnityContainer IoC { get; set; }

        public void Configuration(IAppBuilder app)
        {
            var oAuthProvider = new OAuthServerProvider(IoC.Resolve<IUserManagementService>());

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/v1/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(999),
                Provider = oAuthProvider
            };
            //Enable cors origin requests     
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
