using System.ComponentModel.DataAnnotations;

namespace Store.Models.BindingModels.Order
{
    public class CreateOrderBM
    {

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string ModelName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string ClientName { get; set; }

        [Required]
        [MinLength(3)]
        public string City { get; set; }


        public string School { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }



    }
}
