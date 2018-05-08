using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Implementations
{
    public class Service
    {

        protected StoreContext context { get; }

        public Service()
        {
            this.context = new StoreContext();
        }
    }
}
