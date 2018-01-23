using Store.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Models.ViewModels.Orders
{
    public class EditOrderVM
    {
       
        public string ModelName { get; set; }

       
        public string ClientName { get; set; }

        
        public string City { get; set; }


        public string School { get; set; }

       
        public string PhoneNumber { get; set; }


        public DateTime DateCreated { get; set; }


        public DateTime TestDate { get; set; }

        public DateTime WedingDate { get; set; }


        public int ChestLap { get; set; }

        public int PodgradnaLap { get; set; }

        public int Waist { get; set; }

        public int LowWaist { get; set; }

        public string CutOutDressWorkerName { get; set; }


        public IEnumerable<SelectListItem> Workers { get; set; }

    }
}
