using AutoMapper;
using Store.Models.BindingModels.Manipulations;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels.Categories;
using Store.Models.EntityModels.Manipulations;
using Store.Models.EntityModels.Orders;
using Store.Models.ViewModels.Categories;
using Store.Models.ViewModels.Manipulations;
using Store.Models.ViewModels.Orders;
using Store.Models.ViewModels.Payments;
using System.Globalization;
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
                expression.CreateMap<Category, AllCategoriesVM>();
                expression.CreateMap<Category, EditCategoryVM>();

                expression.CreateMap<Order, AllOrdersVM>()
                .ForMember(c => c.WedingDate, configurationExpression =>
                     configurationExpression.MapFrom(u => u.WedingDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)));


                expression.CreateMap<Order, DetailsOrderVM>()
                .ForMember(c => c.DateCreated, configurationExpression =>
                     configurationExpression.MapFrom(u => u.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(c => c.TestDate, configurationExpression =>
                     configurationExpression.MapFrom(u => u.TestDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(c => c.WedingDate, configurationExpression =>
                     configurationExpression.MapFrom(u => u.WedingDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)));



                expression.CreateMap<Manipulation, PayManipulationsVM>()
                .ForMember(c => c.Category, configurationExpression =>
                     configurationExpression.MapFrom(u => u.Category.Name))
                .ForMember(c => c.ManipulationDate, configurationExpression =>
                     configurationExpression.MapFrom(u => u.ManipulationDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)));

                expression.CreateMap<Manipulation, ListManipulationsVM>()
                .ForMember(c => c.Worker, configurationExpression =>
                     configurationExpression.MapFrom(u => u.Worker.Name))
                .ForMember(c => c.Category, configurationExpression =>
                     configurationExpression.MapFrom(u => u.Category.Name))
                .ForMember(c => c.ManipulationDate, configurationExpression =>
                     configurationExpression.MapFrom(u => u.ManipulationDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture))); ;

                expression.CreateMap<Manipulation, EditManipulationVM>()
                .ForMember(c => c.Worker, configurationExpression =>
                     configurationExpression.MapFrom(u => u.Worker.Name))
                .ForMember(c => c.Category, configurationExpression =>
                     configurationExpression.MapFrom(u => u.Category.Name));


                expression.CreateMap<Order, EditOrderVM>().ForMember(c => c.CutOutDressWorkerName,
                     configurationExpression =>
                     configurationExpression.MapFrom(u => u.CutOutDressWorker.Name));

            });
        }
    }
}
