using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Models.ViewModels.Manipulations
{
    public class CreateManipulationVM
    {
        public string Description { get; set; }

        public int TimeNeeded { get; set; }

        public int Amount { get; set; }

        public string Worker { get; set; }

        public IEnumerable<SelectListItem> Workers { get; set; }

        public int OrderId { get; set; }

        public string Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
