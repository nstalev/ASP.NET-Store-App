using AutoMapper;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels;
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
            IEnumerable<Order> orders = context.Orders.OrderByDescending(o => o.DateCreated);

            IEnumerable<AllOrdersVM> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<AllOrdersVM>>(orders);



            return vms;

        }

        public EditOrderVM GetEditOrderVM(int id)
        {
            Order currentOrder = context.Orders.Find(id);

            EditOrderVM vm = Mapper.Map<Order, EditOrderVM>(currentOrder);

            return vm;

        }

        public List<Worker> getAllWorkers()
        {
            var workers = context.Workers.OrderBy(u => u.Name);

            return workers.ToList(); ;
        }

        public void GetEditOrderVM(EditOrderBM bind)
        {

            Order currentOrder = context.Orders.Find(bind.Id);
            Worker cuOutDressWorker = context.Workers.FirstOrDefault(w => w.Name == bind.CutOutDressWorkerName);

            currentOrder.ModelName = bind.ModelName;
            currentOrder.ClientName = bind.ClientName;
            currentOrder.City = bind.City;
            currentOrder.School = bind.School;
            currentOrder.PhoneNumber = bind.PhoneNumber;
            currentOrder.TestDate = bind.TestDate;
            currentOrder.WedingDate = bind.WedingDate;
            currentOrder.ChestLap = bind.ChestLap;
            currentOrder.PodgradnaLap = bind.PodgradnaLap;
            currentOrder.Waist = bind.Waist;
            currentOrder.LowWaist = bind.LowWaist;
            currentOrder.CutOutDressWorker = cuOutDressWorker;

            context.SaveChanges();



        }

        public object GetDetailsOrderVM(int id)
        {

            Order order = context.Orders.Find(id);

            var vm = Mapper.Map<Order, DetailsOrderVM>(order);

            return vm;
        }
    }
}
