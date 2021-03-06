﻿using AutoMapper;
using Store.Models;
using Store.Models.BindingModels.Manipulations;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Categories;
using Store.Models.EntityModels.Manipulations;
using Store.Models.EntityModels.Orders;
using Store.Models.ViewModels.Manipulations;
using Store.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Implementations
{
    public class OrderService : Service, IOrderService
    {
        public void CreateNewOrder(string userName, CreateOrderBM bind)
        {
            Order newOrder = Mapper.Map<CreateOrderBM, Order>(bind);

            var worker = context.Workers.FirstOrDefault(u => u.User.UserName == userName);

            newOrder.CutOutDressWorker = worker;
            newOrder.DateCreated = DateTime.Now;

            context.Orders.Add(newOrder);
            context.SaveChanges();

        }

        public int Total(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return this.context.Orders.Count();
            }
            else
            {
                return this.context.Orders
                .Where(o => o.ClientName.ToLower().Contains(search.ToLower())
                || o.ModelName.ToLower().Contains(search.ToLower()))
                .Count();
            }

        }

        public IEnumerable<AllOrdersVM> GetOrders(string search, int page)
        {

            var orders = new List<Order>();

            if (String.IsNullOrEmpty(search))
            {
                orders = this.context.Orders
                .OrderByDescending(o => o.DateCreated)
                .Skip(ModelsConstants.OrdersListingPagesize * (page - 1))
                .Take(ModelsConstants.OrdersListingPagesize)
                .ToList();
            }
            else
            {
                orders = this.context.Orders
                .Where(o => o.ClientName.ToLower().Contains(search.ToLower())
                || o.ModelName.ToLower().Contains(search.ToLower()))
                .OrderByDescending(o => o.DateCreated)
                .Skip((page - 1) * ModelsConstants.OrdersListingPagesize)
                .Take(ModelsConstants.OrdersListingPagesize)
                .ToList();
            }


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

        public void EditOrder(EditOrderBM bind)
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

        public DetailsOrderVM GetDetailsOrderVM(int id)
        {

            Order order = context.Orders.Find(id);

            IEnumerable<Manipulation> currentManipulations = order.Manipulations;

            var manipulVM = Mapper.Map<IEnumerable<Manipulation>, IEnumerable<ListManipulationsVM>>(currentManipulations);

            var vm = Mapper.Map<Order, DetailsOrderVM>(order);

            vm.Manipulations = manipulVM;

            return vm;
        }

        public CreateManipulationVM GetCreateManipulationVM(int id)
        {
            CreateManipulationVM vm = new CreateManipulationVM();
            vm.OrderId = id;
            return vm;
        }

        public IEnumerable<Category> getAllCategoris()
        {
            var categories = context.Categories
                .Where(c => c.IsActive == true)
                .OrderBy(c => c.Name);

            return categories;
        }

        public void CreateMaipulation(int orderId, CreateManipulationBM bind)
        {

            Order currentOrder = context.Orders.Find(orderId);
            Worker currentWorker = context.Workers.FirstOrDefault(w => w.Name == bind.Worker);
            // Worker currentWorker = context.Workers.Find(int.Parse(bind.Worker));
            Category selectedCategory = context.Categories.FirstOrDefault(c => c.Name == bind.Category);


            Manipulation manipulation = new Manipulation()
            {
                Description = bind.Description,
                ManipulationDate = DateTime.Now,
                Amount = bind.Amount,
                TimeNeeded = bind.TimeNeeded,
                Category = selectedCategory,
                Order = currentOrder,
                Worker = currentWorker
            };

            context.Manipulations.Add(manipulation);
            context.SaveChanges();


        }

        public EditManipulationVM GetEditManipulationVM(int orderId, int manId)
        {

            Manipulation manipulation = context.Manipulations.Find(manId);

            EditManipulationVM vm = Mapper.Map<Manipulation, EditManipulationVM>(manipulation);

            return vm;
        }

        public void EditManipulation(int manId, EditManipulationBM bind)
        {
            Manipulation currentManipulation = context.Manipulations.Find(manId);


            Worker selectedWorker = context.Workers.FirstOrDefault(w => w.Name == bind.Worker);

            Category selectedCategory = context.Categories.FirstOrDefault(c => c.Name == bind.Category);


            currentManipulation.Description = bind.Description;
            currentManipulation.TimeNeeded = bind.TimeNeeded;
            currentManipulation.Amount = bind.Amount;
            currentManipulation.Worker = selectedWorker;
            currentManipulation.Category = selectedCategory;


            context.SaveChanges();

        }
    }
}
