using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface ICandyService
    {
        List<CandyViewModel> GetList();
        CandyViewModel GetElement(int id);
        void AddElement(CandyBindingModel model);
        void UpdElement(CandyBindingModel model);
        void DelElement(int id);
    }
}
