using POS.WebAPI.App_Start;
using POS.WebAPI.Business;
using POS.WebAPI.Infraestructure;
using POS.WebAPI.Resolver;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace POS.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<IUserManagementService, UserManagementService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<INotificationService, NotificationService>();     
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICatalogService, CatalogService>();       
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IInsuranceService, InsuranceService>();
            container.RegisterType<IMenuService, MenuService>();

            Startup.IoC = container;
            config.DependencyResolver = new UnityResolver(Startup.IoC);
            config.DependencyResolver = new UnityResolver(container);
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
    

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
