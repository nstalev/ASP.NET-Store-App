﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.BindingModels.Manipulations
{
    public class CreateManipulationBM
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int TimeNeeded { get; set; }

        public int Amount { get; set; }

        [Required]
        public string Worker { get; set; }

        [Required]
        public string Category { get; set; }

    }
}
