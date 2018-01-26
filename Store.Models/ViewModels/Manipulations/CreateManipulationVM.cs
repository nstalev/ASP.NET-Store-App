using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Store.Models.ViewModels.Manipulations
{
    public class CreateManipulationVM
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int TimeNeeded { get; set; }

        public int Amount { get; set; }

        [Required]
        public string Worker { get; set; }

        public IEnumerable<SelectListItem> Workers { get; set; }

        public int OrderId { get; set; }

        [Required]
        public string Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
