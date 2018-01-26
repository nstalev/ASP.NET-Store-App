using PagedList;
using Store.Data;
using Store.Models.BindingModels.Manipulations;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Categories;
using Store.Models.ViewModels.Manipulations;
using Store.Models.ViewModels.Orders;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Orders")]
    public class OrderController : Controller
    {
        private OrderService service;
        private StoreContext context;


        public OrderController()
        {
            this.service = new OrderService();
            this.context = new StoreContext();

        }
        // GET: Order
        [Route("")]
        public ActionResult Index(string searchString, int? page)
        {
            IEnumerable<AllOrdersVM> vms;

            if (searchString != null)
            {
                page = 1;
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                vms = service.GetAllOrdersVMWithSearching(searchString);

            }
            else
            {
                vms = service.GetAllOrdersVM();

            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(vms.ToPagedList(pageNumber, pageSize));
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

        [Route("{id}")]
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
