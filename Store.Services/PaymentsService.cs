
using AutoMapper;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Manipulations;
using Store.Models.ViewModels.Payments;
using Store.Models.ViewModels.Payments.ByWorker;
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

            PayCategoryResultVM categoriesResult = GetCategoriesResult(manipulations);

            PayWorkersResultVM vm = new PayWorkersResultVM
            {
                StartDate = startDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                EndDate = endDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                Name = workerName,
                Manipulations = manipulationsVM,
                CategoriesVM = categoriesResult
            };



            return vm;
        }





        public PayCategoryResultVM GetCategoriesResult(IEnumerable<Manipulation> manipulations)
        {

            List<PayCategoriesVM> allCateg = new List<PayCategoriesVM>();

            Dictionary<string, Dictionary<string, double>> categories_time = new Dictionary<string, Dictionary<string, double>>();

            foreach (var manip in manipulations)
            {
                if (!categories_time.ContainsKey(manip.Category.Name))
                {
                    categories_time.Add(manip.Category.Name, new Dictionary<string, double>());
                    categories_time[manip.Category.Name].Add("Time", 0);
                    categories_time[manip.Category.Name].Add("PricePerHour", manip.Category.PricePerHour);
                }

                categories_time[manip.Category.Name]["Time"] += manip.TimeNeeded;


            }

           // double timeSum = 0;
            int minutesSum = 0;
            double paymentSum = 0;

            foreach (var categ in categories_time)
            {
                int minutes = int.Parse(categ.Value["Time"].ToString());

                double timeInHours = categ.Value["Time"] / 60;
                double payment = timeInHours * categ.Value["PricePerHour"];

                PayCategoriesVM vm = new PayCategoriesVM()
                {
                    Name = categ.Key,
                    Hours = minutes / 60,
                    Minutes = minutes % 60,
                    Payment = payment
                };

               // timeSum += categ.Value["Time"];
                minutesSum += minutes;
                paymentSum += payment;

                allCateg.Add(vm);
            }

            PayCategoryResultVM resultVM = new PayCategoryResultVM()
            {
                Categories = allCateg,
                AllPayment = paymentSum,
                SumHours = minutesSum / 60,
                SumMinutes = minutesSum % 60
                
            };

            return resultVM;
        }
    }
}
