using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.ViewModels.Manipulations
{
    public class ListManipulationsVM
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime ManipulationDate { get; set; }

        public int TimeNeeded { get; set; }

        public string Worker { get; set; }

        public string Category { get; set; }

    }
}
