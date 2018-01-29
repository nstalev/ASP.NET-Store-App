using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models.EntityModels;
using Store.Models.ViewModels.Payments;

namespace Store.Services
{
    public class PaymentsService : Service
    {
        public IEnumerable<Worker> getAllWorkers()
        {

            return context.Workers.OrderBy(w => w.Name);
        }
    }
}
