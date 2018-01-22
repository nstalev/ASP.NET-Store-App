
using System.Collections.Generic;
using Store.Models.EntityModels.Orders;

namespace Store.Models.EntityModels
{
    public class Worker
    {

        public Worker()
        {
            this.OrdersCutOutDress = new  HashSet<Order>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

       public virtual ICollection<Order> OrdersCutOutDress { get; set; }

    }
}
