using AbstractSweetShopServiceDAL.Attributies;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с исполнителями")]
    public interface IExecutorService
    {
        [CustomMethod("Метод получения списка исполнителей")]
        List<ExecutorViewModel> GetList();

        [CustomMethod("Метод получения исполнителя по id")]
        ExecutorViewModel GetElement(int id);

        [CustomMethod("Метод добавления исполнителя")]
        void AddElement(ExecutorBindingModel model);

        [CustomMethod("Метод изменения данных по исполнителям")]
        void UpdElement(ExecutorBindingModel model);

        [CustomMethod("Метод удаления исполнителя")]
        void DelElement(int id);

        [CustomMethod("Метод получения свободного исполнителя")]
        ExecutorViewModel GetFreeWorker();
    }
}
