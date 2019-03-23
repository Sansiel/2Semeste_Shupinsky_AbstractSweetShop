using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveCandyPrice(ReportBindingModel model);
        List<StoreLoadViewModel> GetStoreLoad();
        void SaveStoreLoad(ReportBindingModel model);
        List<BuyerJobsViewModel> GetBuyerJobs(ReportBindingModel model);
        void SaveBuyerJobs(ReportBindingModel model);
    }
}
