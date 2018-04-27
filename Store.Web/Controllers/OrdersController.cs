using Store.Data;
using Store.Models;
using Store.Models.BindingModels.Manipulations;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Categories;
using Store.Models.ViewModels.Manipulations;
using Store.Models.ViewModels.Orders;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private OrderService service;
        private StoreContext context;


        public OrdersController()
        {
            this.service = new OrderService();
            this.context = new StoreContext();

        }

        public ActionResult Index(string search, int page = 1)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }

            int totalOrders = this.service.Total(search);

            var orders = new List<AllOrdersVM>();

            if (totalOrders >  0)
            {
                orders = this.service.GetOrders(search, page).ToList(); ;
            }

            var totalPages = (int)Math.Ceiling((double)totalOrders / ModelsConstants.OrdersListingPagesize);

            page = Math.Max(page, 1);
            page = Math.Min(page, totalPages);


            return View(new OrderListingViewModel
            {
                CurrentPage = page,
                Search = search,
                TotalPages = totalPages,
                TotalOrders = totalOrders,
                Orders = orders
            });
        }



        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(CreateOrderBM bind)
        {

            var currentUser = User.Identity.Name;


            if (this.ModelState.IsValid)
            {

                service.CreateNewOrder(currentUser, bind);

                return this.RedirectToAction("Index");
            }

            return View();
        }

        // GET: Order/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditOrderVM vm = service.GetEditOrderVM(id);

            List<Worker> workers = service.getAllWorkers();

            vm.Workers = GetSelectedListWorker(workers);

            return View(vm);
        }




        // POST: Order/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(EditOrderBM bind)
        {

            EditOrderVM vm = service.GetEditOrderVM(bind.Id);

            List<Worker> workers = service.getAllWorkers();

            vm.Workers = GetSelectedListWorker(workers);

            if (this.ModelState.IsValid)
            {
                service.EditOrder(bind);

                return this.RedirectToAction("Index");
            }


            return View(vm);

        }

       // [Route("{id}")]
        public ActionResult Details(int id)
        {

            DetailsOrderVM vm = service.GetDetailsOrderVM(id);

            return View(vm);
        }


        [HttpGet]
        [Route("{Id}/AddManipulation")]
        public ActionResult AddManipulation(int id)
        {
            CreateManipulationVM vm = service.GetCreateManipulationVM(id);

            List<Worker> workers = service.getAllWorkers();

            IEnumerable<Category> categories = service.getAllCategoris();



            vm.Workers = GetSelectedListWorker(workers);
            vm.Categories = GetSelectedListCategories(categories);

            return View(vm);
        }

        [HttpPost]
        [Route("{Id}/AddManipulation")]
        public ActionResult AddManipulation(int id, CreateManipulationBM bind)
        {
            if (this.ModelState.IsValid)
            {

                this.service.CreateMaipulation(id, bind);
                return this.RedirectToAction("Details", new { id });
            }

            CreateManipulationVM vm = service.GetCreateManipulationVM(id);

            List<Worker> workers = service.getAllWorkers();

            IEnumerable<Category> categories = service.getAllCategoris();



            vm.Workers = GetSelectedListWorker(workers);
            vm.Categories = GetSelectedListCategories(categories);


            return View(vm);
        }


        [HttpGet]
        [Route("{orderId}/Manipulations/{manId}/Edit")]
        public ActionResult EditManipulation(int orderId, int manId)
        {

            EditManipulationVM vm = service.GetEditManipulationVM(orderId, manId);

            List<Worker> workers = service.getAllWorkers();

            IEnumerable<Category> categories = service.getAllCategoris();



            vm.Workers = GetSelectedListWorker(workers);
            vm.Categories = GetSelectedListCategories(categories);


            return View(vm);
        }


        [HttpPost]
        [Route("{orderId}/Manipulations/{manId}/Edit")]
        public ActionResult EditManipulation(int orderId, int manId, EditManipulationBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditManipulation(manId, bind);
                return  this.RedirectToAction("Details", new { id = orderId });
            }

            EditManipulationVM vm = service.GetEditManipulationVM(orderId, manId);

            List<Worker> workers = service.getAllWorkers();

            IEnumerable<Category> categories = service.getAllCategoris();



            vm.Workers = GetSelectedListWorker(workers);
            vm.Categories = GetSelectedListCategories(categories);

            return View(vm);
        }







        private IEnumerable<SelectListItem> GetSelectedListWorker(List<Worker> workers)
        {
            var selectList = new List<SelectListItem>();

            foreach (var worker in workers)
            {
                selectList.Add(new SelectListItem
                {
                    Value = worker.Name,
                    Text = worker.Name
                });
            }

            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectedListCategories(IEnumerable<Category> categories)
        {
            var selectList = new List<SelectListItem>();

            foreach (var category in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = category.Name,
                    Text = category.Name
                });
            }

            return selectList;
        }


    }
}
