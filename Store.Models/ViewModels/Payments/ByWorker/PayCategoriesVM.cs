using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.ViewModels.Payments.ByWorker
{
    public class PayCategoriesVM
    {
        public string Name { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public double Payment { get; set; }

    }
}
