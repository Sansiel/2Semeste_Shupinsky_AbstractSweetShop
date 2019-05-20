using AbstractSweetShopServiceDAL.Attributies;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface IBuyerService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<BuyerViewModel> GetList();

        [CustomMethod("Метод получения клиента по id")]
        BuyerViewModel GetElement(int id);

        [CustomMethod("Метод добавления клиента")]
        void AddElement(BuyerBindingModel model);

        [CustomMethod("Метод изменения данных по клиенту")]
        void UpdElement(BuyerBindingModel model);

        [CustomMethod("Метод удаления клиента")]
        void DelElement(int id);
    }
}
