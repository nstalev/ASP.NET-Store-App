using PagedList;
using Store.Data;
using Store.Models.BindingModels.Orders;
using Store.Models.EntityModels;
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



        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {


            return View();
        }







        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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



    }
}
