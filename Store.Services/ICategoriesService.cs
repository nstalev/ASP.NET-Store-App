using System.Collections.Generic;
using Store.Models.BindingModels.Categories;
using Store.Models.ViewModels.Categories;

namespace Store.Services
{
    public interface ICategoriesService
    {
        void CreateNewCategory(CreateCategoryBM bind);
        IEnumerable<AllCategoriesVM> GetAllActiveCategories();
        IEnumerable<AllCategoriesVM> GetAllInActiveCategories();
        void GetEditCategory(EditCategoryBM bind);
        EditCategoryVM GetEditCategoryVM(int id);
    }
}