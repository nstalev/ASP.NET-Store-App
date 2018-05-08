using Store.Models.BindingModels.Categories;
using Store.Models.ViewModels.Categories;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{

    [Authorize]
    public class CategoriesController : Controller
    {

        private readonly ICategoriesService service;

        public CategoriesController(ICategoriesService service)
        {
            this.service = service;
        }




        // GET: Categories
        public ActionResult Index()
        {

            IEnumerable<AllCategoriesVM> vms = this.service.GetAllActiveCategories();

            return View(vms);
        }

        [HttpGet]
        public ActionResult InActive()
        {

            IEnumerable<AllCategoriesVM> vms = this.service.GetAllInActiveCategories();

            return View(vms);
        }




        // GET: Categories/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(CreateCategoryBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.CreateNewCategory(bind);
                return this.RedirectToAction("Index");
            }

                return View();
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {

            EditCategoryVM vm = service.GetEditCategoryVM(id);

            return View(vm);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCategoryBM bind)
        {
            EditCategoryVM vm = service.GetEditCategoryVM(bind.Id);

            if (this.ModelState.IsValid)
            {
                this.service.GetEditCategory(bind);
                return this.RedirectToAction("Index");
            }

            return View(vm);
        }

     
    }
}
