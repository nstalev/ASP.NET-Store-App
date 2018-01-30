using System.ComponentModel.DataAnnotations;

namespace Store.Models.BindingModels.Categories
{
    public class CreateCategoryBM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double PricePerHour { get; set; }
    }
}
