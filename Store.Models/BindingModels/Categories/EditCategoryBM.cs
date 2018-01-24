using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.BindingModels.Categories
{
    public class EditCategoryBM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsActive { get; set; }
    }
}
