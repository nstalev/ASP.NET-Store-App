
using AutoMapper;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Manipulations;
using Store.Models.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                .Where(m => m.ManipulationDate >= startDate && m.ManipulationDate <= endDate );


            IEnumerable<PayManipulationsVM> manipulationsVM = Mapper.Map<IEnumerable<Manipulation>, IEnumerable<PayManipulationsVM>>(manipulations);

            PayWorkersResultVM vm = new PayWorkersResultVM();

            vm.StartDate = startDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            vm.EndDate = endDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            vm.Name = workerName;
            vm.Manipulations = manipulationsVM;



            return vm;
        }
    }
}
