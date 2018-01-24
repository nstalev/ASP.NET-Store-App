using Store.Models.EntityModels.Manipulations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.EntityModels.Categories
{
    public class Category
    {

        public Category()
        {
            this.Manipulations = new HashSet<Manipulation>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        

        [Required]
        public decimal PricePerHour { get; set; }


        public bool IsActive { get; set; }


        public virtual ICollection<Manipulation> Manipulations { get; set; }
    }
}
