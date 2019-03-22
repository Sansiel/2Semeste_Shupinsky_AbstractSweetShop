using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopServiceImplementDataBase.Implementations
{
    public class CandyServiceDB : ICandyService
    {
        private AbstractDbContext context;
        public CandyServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<CandyViewModel> GetList()
        {
            List<CandyViewModel> result = context.Candies.Select(rec => new
            CandyViewModel
            {
                Id = rec.Id,
                CandyName = rec.CandyName,
                Price = rec.Price,
                CandyMaterials = context.CandyMaterials
            .Where(recPC => recPC.CandyId == rec.Id)
            .Select(recPC => new CandyMaterialViewModel
            {
                Id = recPC.Id,
                CandyId = recPC.CandyId,
                MaterialId = recPC.MaterialId,
                MaterialName = recPC.Material.MaterialName,
                Count = recPC.Count
            })
            .ToList()
            })
            .ToList();
            return result;
        }
        public CandyViewModel GetElement(int id)
        {
            Candy element = context.Candies.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CandyViewModel
            {
                    Id = element.Id,
CandyName = element.CandyName,
Price = element.Price,
CandyMaterials = context.CandyMaterials
.Where(recPC => recPC.CandyId == element.Id)
.Select(recPC => new CandyMaterialViewModel
{
    Id = recPC.Id,
    CandyId = recPC.CandyId,
    MaterialId = recPC.MaterialId,
    MaterialName = recPC.Material.MaterialName,
    Count = recPC.Count
})
.ToList()
            };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CandyBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Candy element = context.Candies.FirstOrDefault(rec =>
                    rec.CandyName == model.CandyName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Candy
                    {
                        CandyName = model.CandyName,
                        Price = model.Price
                    };
                    context.Candies.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupMaterials = model.CandyMaterials
                    .GroupBy(rec => rec.MaterialId)
                    .Select(rec => new
                    {
                        MaterialId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    // добавляем компоненты
                    foreach (var groupMaterial in groupMaterials)
                    {
                        context.CandyMaterials.Add(new CandyMaterial
                        {
                            CandyId = element.Id,
                            MaterialId = groupMaterial.MaterialId,
                            Count = groupMaterial.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(CandyBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Candy element = context.Candies.FirstOrDefault(rec =>
                    rec.CandyName == model.CandyName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Candies.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.CandyName = model.CandyName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.CandyMaterials.Select(rec =>
                    rec.MaterialId).Distinct();
                    var updateMaterials = context.CandyMaterials.Where(rec =>
                    rec.CandyId == model.Id && compIds.Contains(rec.MaterialId));
                    foreach (var updateMaterial in updateMaterials)
                    {
                        updateMaterial.Count =
                        model.CandyMaterials.FirstOrDefault(rec => rec.Id == updateMaterial.Id).Count;
                    }
                    context.SaveChanges();
                    context.CandyMaterials.RemoveRange(context.CandyMaterials.Where(rec =>
                    rec.CandyId == model.Id && !compIds.Contains(rec.MaterialId)));
                    context.SaveChanges();
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
                        CandyMaterial elementPC =
                        context.CandyMaterials.FirstOrDefault(rec => rec.CandyId == model.Id &&
                        rec.MaterialId == groupMaterial.MaterialId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupMaterial.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.CandyMaterials.Add(new CandyMaterial
                            {
                                CandyId = model.Id,
                            MaterialId = groupMaterial.MaterialId,
                                Count = groupMaterial.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Candy element = context.Candies.FirstOrDefault(rec => rec.Id ==
                    id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.CandyMaterials.RemoveRange(context.CandyMaterials.Where(rec =>
                        rec.CandyId == id));
                        context.Candies.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}