using System;
using System.Collections.Generic;
using Store.Models.EntityModels;
using Store.Models.EntityModels.Manipulations;
using Store.Models.ViewModels.Payments;
using Store.Models.ViewModels.Payments.ByWorker;

namespace Store.Services
{
    public interface IPaymentsService
    {
        IEnumerable<Worker> getAllWorkers();
        PayCategoryResultVM GetCategoriesResult(IEnumerable<Manipulation> manipulations);
        PayWorkersResultVM getPayWorkersResultVM(string workerName, DateTime startDate, DateTime endDate);
    }
}