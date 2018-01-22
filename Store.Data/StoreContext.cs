namespace Store.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Store.Models.EntityModels;
    using Store.Models.EntityModels.Order;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
       
        public StoreContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Order> Orders { get; set; }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

    }


}