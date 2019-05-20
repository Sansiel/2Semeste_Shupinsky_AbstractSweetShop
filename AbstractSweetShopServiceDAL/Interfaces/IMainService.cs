using AbstractSweetShopServiceDAL.Attributies;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    [CustomInterface("Главный интерфейс")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<JobViewModel> GetList();

        [CustomMethod("Метод получения свободного заказа")]
        List<JobViewModel> GetFreeJobs();

        [CustomMethod("Метод создания заказа")]
        void CreateJob(JobBindingModel model);

        [CustomMethod("Метод принятия на работу заказа")]
        void TakeJobInWork(JobBindingModel model);

        [CustomMethod("Метод окончания работы над заказом")]
        void FinishJob(JobBindingModel model);

        [CustomMethod("Метод оплаты заказа")]
        void PayJob(JobBindingModel model);

        [CustomMethod("Метод добавления материалов на склад")]
        void PutMaterialInStore(StoreMaterialBindingModel model);
    }
}
