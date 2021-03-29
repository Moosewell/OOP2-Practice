using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using BankRepository.Interfaces;
using BankRepository.Classes;
using BankDomain.BankAccounts.BankAccountServices.Interfaces;
using BankDomain.Customers.CustomerService.Interfaces;
using BankDomain.Customers.CustomerService;
using BankDomain.BankAccounts.BankAccountServices;

namespace BankAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static void RegisterSimpleInjector(HttpConfiguration config)
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            // Register your types, for instance using the scoped lifestyle:
            container.Register<IBankAccountService, BankAccountService>(Lifestyle.Scoped);
            container.Register<ICustomerService, CustomerService>(Lifestyle.Scoped);
            container.Register<IBankAccountRepository, AzureRepository>(Lifestyle.Scoped);
            container.Register<ICustomerRepository, AzureRepository>(Lifestyle.Scoped);
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
