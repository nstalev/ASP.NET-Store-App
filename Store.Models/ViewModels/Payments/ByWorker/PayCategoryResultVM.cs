using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
