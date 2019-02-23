using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopServiceImplementList.Implemetations
{
    public class CandyServiceList : ICandyService
    {
        private DataListSingleton source;

        public CandyServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CandyViewModel> GetList()
        {
            List<CandyViewModel> result = source.Candies.Select(rec => new CandyViewModel
            {
                Id = rec.Id,
                CandyName = rec.CandyName,
                Price = rec.Price,
                CandyMaterials = source.CandyMaterials.Where(recPC => recPC.CandyId == rec.Id).Select(recPC => new CandyMaterialViewModel
                {
                    Id = recPC.Id,
                    CandyId = recPC.CandyId,
                    MaterialId = recPC.MaterialId,
                    MaterialName = source.Materials.FirstOrDefault(recC => recC.Id == recPC.MaterialId)?.MaterialName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;
        }
        public CandyViewModel GetElement(int id)
        {
            Candy element = source.Candies.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CandyViewModel
                {
                    Id = element.Id,
                    CandyName = element.CandyName,
                    Price = element.Price,
                    CandyMaterials = source.CandyMaterials.Where(recPC => recPC.CandyId == element.Id).Select(recPC => new CandyMaterialViewModel
                    {
                        Id = recPC.Id,
                        CandyId = recPC.CandyId,
                        MaterialId = recPC.MaterialId,
                        MaterialName = source.Materials.FirstOrDefault(recC => recC.Id == recPC.MaterialId)?.MaterialName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CandyBindingModel model)
        {
            Candy element = source.Candies.FirstOrDefault(rec => rec.CandyName == model.CandyName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Candies.Count > 0 ? source.Candies.Max(rec => rec.Id) : 0;
            source.Candies.Add(new Candy
            {
                Id = maxId + 1,
                CandyName = model.CandyName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.CandyMaterials.Count > 0 ? source.CandyMaterials.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам 
            var groupComponents = model.CandyMaterials.GroupBy(rec => rec.MaterialId).Select(rec => new
            {
                MaterialId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents)
            {
                source.CandyMaterials.Add(new CandyMaterial
                {
                    Id = ++maxPCId,
                    CandyId = maxId + 1,
                    MaterialId = groupComponent.MaterialId,
                    Count = groupComponent.Count
                });
            }
        }

        public void UpdElement(CandyBindingModel model)
        {
            Candy element = source.Candies.FirstOrDefault(rec => rec.CandyName == model.CandyName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Candies.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.CandyName = model.CandyName; element.Price = model.Price;
            int maxPCId = source.CandyMaterials.Count > 0 ? source.CandyMaterials.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты 
            var compIds = model.CandyMaterials.Select(rec => rec.MaterialId).Distinct();
            var updateMaterials = source.CandyMaterials.Where(rec => rec.CandyId == model.Id && compIds.Contains(rec.MaterialId));
            foreach (var updateMaterial in updateMaterials)
            {
                updateMaterial.Count = model.CandyMaterials.FirstOrDefault(rec => rec.Id == updateMaterial.Id).Count;
            }
            source.CandyMaterials.RemoveAll(rec => rec.CandyId == model.Id && !compIds.Contains(rec.MaterialId));
            // новые записи          
            var groupMaterials = model.CandyMaterials
                .Where(rec => rec.Id == 0)                  
                .GroupBy(rec => rec.MaterialId)               
                .Select(rec => new
                {
                    MaterialId = rec.Key,
                    Count = rec.Sum(r => r.Count)
                });
            foreach (var groupMaterial in groupMaterials)
            {
                CandyMaterial elementPC = source.CandyMaterials.FirstOrDefault(rec => rec.CandyId == model.Id && rec.MaterialId == groupMaterial.MaterialId);
                if (elementPC != null)
                {
                    elementPC.Count += groupMaterial.Count;
                }
                else
                {
                    source.CandyMaterials.Add(new CandyMaterial
                    {
                        Id = ++maxPCId,
                        CandyId = model.Id,
                        MaterialId = groupMaterial.MaterialId,
                        Count = groupMaterial.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Candy element = source.Candies.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия         
                source.CandyMaterials.RemoveAll(rec => rec.CandyId == id);
                source.Candies.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
