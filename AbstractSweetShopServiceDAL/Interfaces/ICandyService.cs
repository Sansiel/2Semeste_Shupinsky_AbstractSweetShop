using AbstractSweetShopServiceDAL.Attributies;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с конфетами")]
    public interface ICandyService
    {
        [CustomMethod("Метод получения списка конфет")]
        List<CandyViewModel> GetList();

        [CustomMethod("Метод получения конфеты по id")]
        CandyViewModel GetElement(int id);

        [CustomMethod("Метод добавления конфеты")]
        void AddElement(CandyBindingModel model);

        [CustomMethod("Метод изменения данных по конфете")]
        void UpdElement(CandyBindingModel model);

        [CustomMethod("Метод удаления конфеты")]
        void DelElement(int id);
    }
}
