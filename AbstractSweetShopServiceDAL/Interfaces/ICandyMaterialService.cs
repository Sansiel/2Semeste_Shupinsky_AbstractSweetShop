using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface ICandyMaterialService
    {
        List<CandyMaterialViewModel> GetList();
        CandyMaterialViewModel GetElement(int id);
        void AddElement(CandyMaterialBindingModel model);
        void UpdElement(CandyMaterialBindingModel model);
        void DelElement(int id);
    }
}
