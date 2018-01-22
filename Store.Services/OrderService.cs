using AutoMapper;
using Store.Models.BindingModels.Order;
using Store.Models.EntityModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class OrderService : Service
    {
        public void CreateNewOrder(CreateOrderBM bind)
        {
            Order newOrder = Mapper.Map<CreateOrderBM, Order>(bind);
            context.Orders.Add(newOrder);
            context.SaveChanges();

        }
    }
}
