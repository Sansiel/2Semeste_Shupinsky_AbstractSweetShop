using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IBuyerService
    {
        List<BuyerViewModel> GetList();
        BuyerViewModel GetElement(int id);
        void AddElement(BuyerBindingModel model);
        void UpdElement(BuyerBindingModel model);
        void DelElement(int id);
    }
}
