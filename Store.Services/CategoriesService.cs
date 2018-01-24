using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.Models.BindingModels.Categories;
using Store.Models.EntityModels.Categories;
using Store.Models.ViewModels.Categories;

namespace Store.Services
{
    public class CategoriesService : Service
    {
        public void CreateNewCategory(CreateCategoryBM bind)
        {
            Category category = new Category()
            {
                Name = bind.Name,
                PricePerHour = bind.PricePerHour,
                IsActive = true
            };
            context.Categories.Add(category);
            context.SaveChanges();

        }

        public IEnumerable<AllActiveCategoriesVM> GetAllActiveCategories()
        {
            IEnumerable<Category> activeCategories = context.Categories.Where(c => c.IsActive == true).OrderBy(cat => cat.Name);

            var vms = Mapper.Map<IEnumerable<Category>, IEnumerable<AllActiveCategoriesVM>>(activeCategories);

            return vms;
        }
    }
}
