using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<JobViewModel> GetList();
        List<JobViewModel> GetFreeJobs();
        void CreateJob(JobBindingModel model);
        void TakeJobInWork(JobBindingModel model);
        void FinishJob(JobBindingModel model);
        void PayJob(JobBindingModel model);
        void PutMaterialInStore(StoreMaterialBindingModel model);
    }
}
