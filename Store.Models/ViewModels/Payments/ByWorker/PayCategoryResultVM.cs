using System.Collections.Generic;

namespace Store.Models.ViewModels.Payments.ByWorker
{
    public class PayCategoryResultVM
    {

        public IEnumerable<PayCategoriesVM> Categories { get; set; }


        public int SumHours { get; set; }

        public int SumMinutes { get; set; }


        public double AllPayment { get; set; }

    }
}
