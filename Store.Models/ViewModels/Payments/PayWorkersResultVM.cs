using Store.Models.ViewModels.Payments.ByWorker;
using System.Collections.Generic;

namespace Store.Models.ViewModels.Payments
{
    public class PayWorkersResultVM
    {
        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public IEnumerable<PayManipulationsVM> Manipulations { get; set; }

        public PayCategoryResultVM CategoriesVM { get; set; }
    }
}
