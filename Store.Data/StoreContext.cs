namespace Store.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Store.Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
       
        public StoreContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

    }


}