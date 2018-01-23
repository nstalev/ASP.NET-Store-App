using System;

namespace Store.Models.ViewModels.Orders
{
    public class AllOrdersVM
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public string ClientName { get; set; }

        public string City { get; set; }

        public DateTime WedingDate { get; set; }

    }
}
