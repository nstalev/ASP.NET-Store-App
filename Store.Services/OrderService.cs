using AutoMapper;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels.Orders;
using Store.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class OrderService : Service
    {
        public void CreateNewOrder(string userName,CreateOrderBM bind)
        {
            Order newOrder = Mapper.Map<CreateOrderBM, Order>(bind);

            var worker = context.Workers.FirstOrDefault(u => u.User.UserName == userName);

            newOrder.CutOutDressWorker = worker;
            newOrder.DateCreated = DateTime.Now;
            
            context.Orders.Add(newOrder);
            context.SaveChanges();

        }

        public IEnumerable<AllOrdersVM> GetAllOrdersVM()
        {
            IEnumerable<Order> orders = context.Orders;

            IEnumerable<AllOrdersVM> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<AllOrdersVM>>(orders);



            return vms;

        }
    }
}
