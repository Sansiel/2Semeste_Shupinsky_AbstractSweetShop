using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IExecutorService
    {
        List<ExecutorViewModel> GetList();
        ExecutorViewModel GetElement(int id);
        void AddElement(ExecutorBindingModel model);
        void UpdElement(ExecutorBindingModel model);
        void DelElement(int id);
        ExecutorViewModel GetFreeWorker();
    }
}
