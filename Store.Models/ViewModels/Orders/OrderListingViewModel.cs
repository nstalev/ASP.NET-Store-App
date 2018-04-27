using System;
using System.Collections.Generic;

namespace Store.Models.ViewModels.Orders
{
    public class OrderListingViewModel
    {
        public IEnumerable<AllOrdersVM> Orders { get; set; }

        public int CurrentPage { get; set; }

        public string Search { get; set; }

        public int TotalOrders { get; set; }

        public int TotalPages  { get; set; }

        public int PreviousPage => CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

    }
}
