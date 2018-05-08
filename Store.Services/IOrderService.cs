using System.Collections.Generic;
using Store.Models.BindingModels.Manipulations;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Categories;
using Store.Models.ViewModels.Manipulations;
using Store.Models.ViewModels.Orders;

namespace Store.Services
{
    public interface IOrderService
    {
        void CreateMaipulation(int orderId, CreateManipulationBM bind);
        void CreateNewOrder(string userName, CreateOrderBM bind);
        void EditManipulation(int manId, EditManipulationBM bind);
        void EditOrder(EditOrderBM bind);
        IEnumerable<Category> getAllCategoris();
        List<Worker> getAllWorkers();
        CreateManipulationVM GetCreateManipulationVM(int id);
        DetailsOrderVM GetDetailsOrderVM(int id);
        EditManipulationVM GetEditManipulationVM(int orderId, int manId);
        EditOrderVM GetEditOrderVM(int id);
        IEnumerable<AllOrdersVM> GetOrders(string search, int page);
        int Total(string search);
    }
}