using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Models.ViewModels.Payments
{
    public class PaySearchWorkersVM
    {

        public string Worker { get; set; }

        public IEnumerable<SelectListItem> Workers { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set;
        }
    }
}
