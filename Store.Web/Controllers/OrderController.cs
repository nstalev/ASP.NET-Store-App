using Store.Models.BindingModels.Orders;
using Store.Models.ViewModels.Orders;
using Store.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private OrderService service;

        public OrderController()
        {
            this.service = new OrderService();

        }
        // GET: Order
        public ActionResult Index()
        {

            IEnumerable<AllOrdersVM> vms = service.GetAllOrdersVM();

            return View(vms);
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
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
