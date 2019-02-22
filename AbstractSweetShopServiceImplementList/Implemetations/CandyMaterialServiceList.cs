using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopServiceImplementList.Implemetations
{
    public class CandyMaterialServiceList : ICandyMaterialService
    {
        private DataListSingleton source;

        public CandyMaterialServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(CandyMaterialBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].Id > maxId)
                {
                    maxId = source.CandyMaterials[i].Id;
                }
                if (source.CandyMaterials[i].MaterialName == model.MaterialName)
                {
                    throw new Exception("Уже есть материал с таким именем");
                }
            }
            source.CandyMaterials.Add(new CandyMaterial
            {
                Id = maxId + 1,
                CandyId = model.CandyId,
                MaterialId = model.MaterialId,
                Count = model.Count,
                MaterialName = model.MaterialName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].Id == id)
                {
                    source.CandyMaterials.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public CandyMaterialViewModel GetElement(int id)
        {
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].Id == id)
                {
                    return new CandyMaterialViewModel
                    {
                        Id = source.CandyMaterials[i].Id,
                        MaterialName = source.CandyMaterials[i].MaterialName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<CandyMaterialViewModel> GetList()
        {
            List<CandyMaterialViewModel> result = new List<CandyMaterialViewModel>();
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                result.Add(new CandyMaterialViewModel
                {
                    Id = source.CandyMaterials[i].Id,
                    CandyId = source.CandyMaterials[i].CandyId,
                    MaterialId = source.CandyMaterials[i].MaterialId,
                    Count = source.CandyMaterials[i].Count,
                    MaterialName = source.CandyMaterials[i].MaterialName
                });
            }
            return result;
        }

        public void UpdElement(CandyMaterialBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.CandyMaterials[i].MaterialName == model.MaterialName &&
                source.CandyMaterials[i].Id != model.Id)
                {
                    throw new Exception("Уже есть материал с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.CandyMaterials[index].MaterialName = model.MaterialName;
        }
    }
}
