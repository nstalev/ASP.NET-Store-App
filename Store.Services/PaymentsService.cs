
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

            List<PayCategoriesVM> allCategories = new List<PayCategoriesVM>();

            Dictionary<string, Dictionary<string, double>> categories_time = new Dictionary<string, Dictionary<string, double>>();

            foreach (var manipulation in manipulations)
            {
                if (!categories_time.ContainsKey(manipulation.Category.Name))
                {
                    categories_time.Add(manipulation.Category.Name, new Dictionary<string, double>());
                    categories_time[manipulation.Category.Name].Add("Time", 0);
                    categories_time[manipulation.Category.Name].Add("PricePerHour", manipulation.Category.PricePerHour);
                }

                categories_time[manipulation.Category.Name]["Time"] += manipulation.TimeNeeded;
            }

            int minutesSum = 0;
            double paymentSum = 0;

            foreach (var category in categories_time)
            {
                int minutes = int.Parse(category.Value["Time"].ToString());

                double timeInHours = category.Value["Time"] / 60;
                double payment = timeInHours * category.Value["PricePerHour"];

                PayCategoriesVM vm = new PayCategoriesVM()
                {
                    Name = category.Key,
                    Hours = minutes / 60,
                    Minutes = minutes % 60,
                    Payment = payment
                };

                minutesSum += minutes;
                paymentSum += payment;

                allCategories.Add(vm);
            }

            PayCategoryResultVM resultVM = new PayCategoryResultVM()
            {
                Categories = allCategories,
                AllPayment = paymentSum,
                SumHours = minutesSum / 60,
                SumMinutes = minutesSum % 60
                
            };

            return resultVM;
        }
    }
}
