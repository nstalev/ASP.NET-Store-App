using Store.Models.BindingModels.Order;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ModelName, ClientName, City, School, PhoneNumber")]CreateOrderBM bind)
        {
            if (this.ModelState.IsValid)
            {

                service.CreateNewOrder(bind);

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
