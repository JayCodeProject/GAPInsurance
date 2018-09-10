using System.Web.Http;
using Swashbuckle.Application;
using WebActivatorEx;
using POS.WebAPI;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace POS.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "AI.WebAPI"))
              .EnableSwaggerUi();
        }
    }
}