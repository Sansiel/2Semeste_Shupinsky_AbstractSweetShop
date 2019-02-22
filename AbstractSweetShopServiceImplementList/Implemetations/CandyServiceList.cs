using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

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
            List<CandyViewModel> result = new List<CandyViewModel>();
            for (int i = 0; i < source.Candies.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<CandyMaterialViewModel> CandyMaterials = new List<CandyMaterialViewModel>();
                for (int j = 0; j < source.CandyMaterials.Count; ++j)
                {
                    if (source.CandyMaterials[j].CandyId == source.Candies[i].Id)
                    {
                        string MaterialName = string.Empty;
                        for (int k = 0; k < source.Materials.Count; ++k)
                        {
                            if (source.CandyMaterials[j].MaterialId == source.Materials[k].Id)
                            {
                                MaterialName = source.Materials[k].MaterialName;
                                break;
                            }
                        }
                        CandyMaterials.Add(new CandyMaterialViewModel
                        {
                            Id = source.CandyMaterials[j].Id,
                            CandyId = source.CandyMaterials[j].CandyId,
                            MaterialId = source.CandyMaterials[j].MaterialId,
                            MaterialName = MaterialName,
                            Count = source.CandyMaterials[j].Count
                        });
                    }
                }
                result.Add(new CandyViewModel
                {
                    Id = source.Candies[i].Id,
                    CandyName = source.Candies[i].CandyName,
                    Price = source.Candies[i].Price,
                    CandyMaterials = CandyMaterials
                });
            }
            return result;
        }
        public CandyViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Candies.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<CandyMaterialViewModel> CandyMaterials = new List<CandyMaterialViewModel>();
                for (int j = 0; j < source.CandyMaterials.Count; ++j)
                {
                    if (source.CandyMaterials[j].CandyId == source.Candies[i].Id)
                    {
                        string MaterialName = string.Empty;
                        for (int k = 0; k < source.Materials.Count; ++k)
                        {
                            if (source.CandyMaterials[j].MaterialId == source.Materials[k].Id)
                            {
                                MaterialName = source.Materials[k].MaterialName;
                                break;
                            }
                        }
                        CandyMaterials.Add(new CandyMaterialViewModel
                        {
                            Id = source.CandyMaterials[j].Id,
                            CandyId = source.CandyMaterials[j].CandyId,
                            MaterialId = source.CandyMaterials[j].MaterialId,
                            MaterialName = MaterialName,
                            Count = source.CandyMaterials[j].Count
                        });
                    }
                }
                if (source.Candies[i].Id == id)
                {
                    return new CandyViewModel
                    {
                        Id = source.Candies[i].Id,
                        CandyName = source.Candies[i].CandyName,
                        Price = source.Candies[i].Price,
                        CandyMaterials = CandyMaterials
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CandyBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Candies.Count; ++i)
            {
                if (source.Candies[i].Id > maxId)
                {
                    maxId = source.Candies[i].Id;
                }
                if (source.Candies[i].CandyName == model.CandyName)
                {
                    throw new Exception("Уже есть конфета с таким названием");
                }
            }
            source.Candies.Add(new Candy
            {
                Id = maxId + 1,
                CandyName = model.CandyName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].Id > maxPCId)
                {
                    maxPCId = source.CandyMaterials[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.CandyMaterials.Count; ++i)
            {
                for (int j = 1; j < model.CandyMaterials.Count; ++j)
                {
                    if (model.CandyMaterials[i].MaterialId ==
                    model.CandyMaterials[j].MaterialId)
                    {
                        model.CandyMaterials[i].Count +=
                        model.CandyMaterials[j].Count;
                        model.CandyMaterials.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.CandyMaterials.Count; ++i)
            {
                source.CandyMaterials.Add(new CandyMaterial
                {
                    Id = ++maxPCId,
                    CandyId = maxId + 1,
                    MaterialId = model.CandyMaterials[i].MaterialId,
                    Count = model.CandyMaterials[i].Count
                });
            }
        }
        public void UpdElement(CandyBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Candies.Count; ++i)
            {
                if (source.Candies[i].Id == model.Id)
                {
                index = i;
                }
                if (source.Candies[i].CandyName == model.CandyName &&
                source.Candies[i].Id != model.Id)
                {
                    throw new Exception("Уже есть конфета с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Candies[index].CandyName = model.CandyName;
            source.Candies[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].Id > maxPCId)
                {
                    maxPCId = source.CandyMaterials[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].CandyId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.CandyMaterials.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.CandyMaterials[i].Id == model.CandyMaterials[j].Id)
                        {
                            source.CandyMaterials[i].Count = model.CandyMaterials[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.CandyMaterials.RemoveAt(i--);
                    }
                }
            }

            // новые записи
            for (int i = 0; i < model.CandyMaterials.Count; ++i)
            {
                if (model.CandyMaterials[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.CandyMaterials.Count; ++j)
                    {
                        if (source.CandyMaterials[j].CandyId == model.Id &&
                        source.CandyMaterials[j].MaterialId == model.CandyMaterials[i].MaterialId)
                        {
                            source.CandyMaterials[j].Count += model.CandyMaterials[i].Count;
                            model.CandyMaterials[i].Id = source.CandyMaterials[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.CandyMaterials[i].Id == 0)
                    {
                        source.CandyMaterials.Add(new CandyMaterial
                        {
                            Id = ++maxPCId,
                            CandyId = model.Id,
                            MaterialId = model.CandyMaterials[i].MaterialId,
                            Count = model.CandyMaterials[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.CandyMaterials.Count; ++i)
            {
                if (source.CandyMaterials[i].CandyId == id)
                {
                    source.CandyMaterials.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Candies.Count; ++i)
            {
                if (source.Candies[i].Id == id)
                {
                    source.Candies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
