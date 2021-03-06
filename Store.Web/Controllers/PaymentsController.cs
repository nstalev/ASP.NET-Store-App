﻿using Store.Models.BindingModels.Payments;
using Store.Models.EntityModels;
using Store.Models.ViewModels.Payments;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Web.Controllers
{

    [RoutePrefix("Payments")]
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly IPaymentsService service;

        public PaymentsController(IPaymentsService service)
        {
            this.service = service;
        }

        // GET: Payments
        public ActionResult Index()
        {
            return View();
        }


        [Route("Workers")]
        public ActionResult Workers()
        {
            PaySearchWorkersVM vm = new PaySearchWorkersVM();

            IEnumerable<Worker> workers = service.getAllWorkers();

            vm.Workers = GetSelectedListWorker(workers);

            return View(vm);

        }


        [Route("Workers")]
        [HttpPost]
        public ActionResult Workers(PaySearchWorkersBM bind)
        {
            if (this.ModelState.IsValid)
            {
                return RedirectToAction("WorkersResult", new { worker = bind.Worker, startDate = bind.StartDate, endDate = bind.EndDate });
            }

            PaySearchWorkersVM vm = new PaySearchWorkersVM();
            IEnumerable<Worker> workers = service.getAllWorkers();
            vm.Workers = GetSelectedListWorker(workers);

            return View(vm);

        }

        [Route("WorkerResult")]
        public ActionResult WorkersResult(string worker, DateTime startDate, DateTime endDate)
        {

            PayWorkersResultVM vm = service.getPayWorkersResultVM(worker, startDate, endDate);

            return View(vm);
        }








        private IEnumerable<SelectListItem> GetSelectedListWorker(IEnumerable<Worker> workers)
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