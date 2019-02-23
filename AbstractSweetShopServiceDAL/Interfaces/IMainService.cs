using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<JobViewModel> GetList();
        void CreateOrder(JobBindingModel model);
        void TakeOrderInWork(JobBindingModel model);
        void FinishOrder(JobBindingModel model);
        void PayOrder(JobBindingModel model);
    }
}
