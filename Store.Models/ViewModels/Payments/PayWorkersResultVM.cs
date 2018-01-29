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

        IEnumerable<PayCategoriesVM> categories { get; set; }
    }
}
