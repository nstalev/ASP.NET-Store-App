using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.BindingModels.Manipulations
{
    public class CreateManipulationBM
    {

        public string Description { get; set; }

        public int TimeNeeded { get; set; }

        public int Amount { get; set; }

        public string Worker { get; set; }

        public string Category { get; set; }

    }
}
