using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using ShopeBridgeBusiness;
using ShopBridgeRepository;

namespace ShopeBridge
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static Container container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            container = new Container();

            // 2. Configure the container (register)
            container.Register<IProductService, ProductService>();
            container.Register<IProductRepository, ProductRepository>();

            // 3. Verify your configuration
            container.Verify();
        }
    }
}
