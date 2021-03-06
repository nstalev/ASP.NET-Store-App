﻿using Store.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Implementations
{
    public class AccountService : Service, IAccountService
    {
        public void creataWorker(string id)
        {
            Worker worker = new Worker();

            var user = context.Users.Find(id);

            worker.User = user;
            worker.Name = user.FullName;
            context.Workers.Add(worker);

            context.SaveChanges();

        }
    }
}
