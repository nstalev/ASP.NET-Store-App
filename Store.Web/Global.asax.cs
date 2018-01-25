﻿using AutoMapper;
using Store.Models.BindingModels.Manipulations;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels.Categories;
using Store.Models.EntityModels.Manipulations;
using Store.Models.EntityModels.Orders;
using Store.Models.ViewModels.Categories;
using Store.Models.ViewModels.Orders;
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
                expression.CreateMap<CreateOrderBM, AllOrdersVM>();
                expression.CreateMap<Order, DetailsOrderVM>();
                expression.CreateMap<Category, AllCategoriesVM>();
                expression.CreateMap<Category, EditCategoryVM>();

                
                expression.CreateMap<Order, EditOrderVM>().ForMember(c => c.CutOutDressWorkerName,
                     configurationExpression =>
                     configurationExpression.MapFrom(u => u.CutOutDressWorker.Name));

            });
        }
    }
}
