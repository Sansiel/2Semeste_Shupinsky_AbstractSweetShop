using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IClientService
    {
        List<ClientViewModel> GetList();
        ClientViewModel GetElement(int id);
        void AddElement(ClientBindingModel model);
        void UpdElement(ClientBindingModel model);
        void DelElement(int id);
    }
}
