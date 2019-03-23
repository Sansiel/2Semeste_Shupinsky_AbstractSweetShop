using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    interface IReportService
    {
        void SaveProductPrice(ReportBindingModel model);
        List<StoreLoadViewModel> GetStoreLoad();
        void SaveStoreLoad(ReportBindingModel model);
        List<BuyerJobsViewModel> GetBuyerJobs(ReportBindingModel model);
        void SaveBuyerJobs(ReportBindingModel model);
    }
}
