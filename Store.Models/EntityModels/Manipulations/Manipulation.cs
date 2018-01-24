using Store.Models.EntityModels.Categories;
using Store.Models.EntityModels.Orders;
using System;

namespace Store.Models.EntityModels.Manipulations
{
    public class Manipulation
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime ManipulationDate { get; set; }

        public int TimeNeeded { get; set; }

        public int Amount { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Order Order { get; set; }

        public virtual Category Category { get; set; }

    }
}
