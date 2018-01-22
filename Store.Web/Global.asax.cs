using AutoMapper;
using Store.Models.BindingModels.Order;
using Store.Models.EntityModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Store.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<CreateOrderBM, Order>();

            });
        }
    }
}
