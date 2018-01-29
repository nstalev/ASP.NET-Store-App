using Store.Models.EntityModels;
using Store.Models.ViewModels.Payments;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class PaymentsController : Controller
    {

        private readonly PaymentsService service;

        public PaymentsController()
        {
            this.service = new PaymentsService();
        }

        // GET: Payments
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Workers()
        {
            PaySearchWorkersVM vm = new PaySearchWorkersVM();

            IEnumerable<Worker> workers = service.getAllWorkers();

            vm.Workers = GetSelectedListWorker(workers);

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