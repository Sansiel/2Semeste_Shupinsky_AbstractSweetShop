using AbstractSweetShopServiceDAL.Attributies;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод сохранения прайс-листа")]
        void SaveCandyPrice(ReportBindingModel model);

        [CustomMethod("Метод получения отчета по загруженности складов")]
        List<StoreLoadViewModel> GetStoreLoad();

        [CustomMethod("Метод сохранения отчета по загруженности складов")]
        void SaveStoreLoad(ReportBindingModel model);

        [CustomMethod("Метод получения отчета по заказам")]
        List<BuyerJobsViewModel> GetBuyerJobs(ReportBindingModel model);

        [CustomMethod("Метод сохранения отчета по заказам")]
        void SaveBuyerJobs(ReportBindingModel model);
    }
}
