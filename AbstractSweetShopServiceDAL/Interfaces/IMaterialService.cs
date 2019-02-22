using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.Interfaces
{
    public interface IMaterialService
    {
        List<MaterialViewModel> GetList();
		MaterialViewModel GetElement(int id);
        void AddElement(MaterialBindingModel model);
        void UpdElement(MaterialBindingModel model);
        void DelElement(int id);
    }
}
