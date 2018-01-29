using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Manipulations;
using Store.Models.ViewModels.Payments;

namespace Store.Services
{
    public class PaymentsService : Service
    {
        public IEnumerable<Worker> getAllWorkers()
        {

            return context.Workers.OrderBy(w => w.Name);
        }

        public PayWorkersResultVM getPayWorkersResultVM(string workerName, DateTime startDate, DateTime endDate)
        {
            Worker currentWorker = context.Workers.FirstOrDefault(w => w.Name == workerName);

            IEnumerable<Manipulation> manipulations = currentWorker.Manipulations
                .Where(m => m.ManipulationDate >= startDate && m.ManipulationDate <= endDate);

            throw new NotImplementedException();
        }
    }
}
