using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models.Attributes;

namespace Store.Models.BindingModels
{
    public class Customer
    {
        public int ID { get; set; }

        [SCode]
        public string Name { get; set; }
    }
}
