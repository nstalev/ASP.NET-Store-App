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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
       // public ActionResult Create([Bind(Include = "ModelName, ClientName, City, School, PhoneNumber, TestDate, ")]CreateOrderBM bind)
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
        public ActionResult Edit(int id)
        {
            EditOrderVM vm = service.GetEditOrderVM(id);

             List<Worker> workers = service.getAllWorkers();

                vm.Workers = GetSelectedListWorker(workers);

            return View(vm);
        }




        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(EditOrderBM bind )
        {

            EditOrderVM vm = service.GetEditOrderVM(bind.Id);

            List<Worker> workers = service.getAllWorkers();

            vm.Workers = GetSelectedListWorker(workers);

            if (this.ModelState.IsValid)
            {
                service.GetEditOrderVM(bind);

                return this.RedirectToAction("Index");
            }


            return View(vm);
            
        }


        public ActionResult Details(int id)
        {

            var vm = service.GetDetailsOrderVM(id);

            return View(vm);
        }




        [HttpGet]
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
        public ActionResult AddManipulation(int id, CreateManipulationBM bind)
        {
            if (this.ModelState.IsValid)
            {

                this.service.CreateMaipulation(id, bind);
                return this.RedirectToAction("Index");
            }

            return View();
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
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }

            return selectList;
        }


    }
}
