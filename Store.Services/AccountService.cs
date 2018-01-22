using Store.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class AccountService : Service
    {
        public void creataWorker(string id)
        {
            Worker worker = new Worker();

            var user = context.Users.Find(id);

            worker.User = user;
            context.Workers.Add(worker);

            context.SaveChanges();

        }
    }
}
