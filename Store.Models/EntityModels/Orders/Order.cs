using Store.Models.EntityModels.Manipulations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.EntityModels.Orders
{
    public class Order
    {

        public Order()
        {
            this.Manipulations = new HashSet<Manipulation>();
        }

        public int Id { get; set; }

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


        public DateTime DateCreated { get; set; }


        public DateTime TestDate { get; set; }

        public DateTime WedingDate { get; set; }


        public int ChestLap { get; set; }

        public int PodgradnaLap { get; set; }

        public int Waist { get; set; }

        public int LowWaist { get; set; }


        public virtual Worker CutOutDressWorker { get; set; }

        public virtual ICollection<Manipulation> Manipulations { get; set; }


    }
}
