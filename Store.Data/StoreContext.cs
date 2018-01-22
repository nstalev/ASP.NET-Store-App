namespace Store.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Store.Models.EntityModels;
    using Store.Models.EntityModels.Orders;
    using System.Data.Entity;

    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
       
        public StoreContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Worker> Workers { get; set; }



        public static StoreContext Create()
        {
            return new StoreContext();
        }

    }


}