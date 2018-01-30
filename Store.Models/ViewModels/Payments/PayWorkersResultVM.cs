using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.ViewModels.Payments
{
    public class PayWorkersResultVM
    {
        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public IEnumerable<PayManipulationsVM> Manipulations { get; set; }

        public IEnumerable<PayCategoriesVM> Categories { get; set; }
    }
}
