using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.ViewModels.Orders
{
    public class CreateOrderVM
    {
        public string ModelName { get; set; }

        public string ClientName { get; set; }

        public string City { get; set; }

        public string School { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime TestDate { get; set; }

        public DateTime WedingDate { get; set; }

        public int ChestLap { get; set; }

        public int PodgradnaLap { get; set; }

        public int Waist { get; set; }

        public int LowWaist { get; set; }

    }
}
