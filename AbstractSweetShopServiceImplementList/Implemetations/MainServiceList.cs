using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopServiceImplementList.Implemetations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<JobViewModel> GetList()
        {
            List<JobViewModel> result = source.Jobs
                .Select(rec => new JobViewModel
                {
                    Id = rec.Id,
                    BuyerId = rec.BuyerId,
                    CandyId = rec.CandyId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    BuyerFIO = source.Buyers.FirstOrDefault(recC => recC.Id == rec.BuyerId)?.BuyerFIO,
                    CandyName = source.Candies.FirstOrDefault(recP => recP.Id == rec.CandyId)?.CandyName,
                })
                .ToList();
            return result;
        }
        public void CreateOrder(JobBindingModel model)
        {
            int maxId = source.Jobs.Count > 0 ? source.Jobs.Max(rec => rec.Id) : 0; source.Jobs.Add(new Job
            {
                Id = maxId + 1,
                BuyerId = model.BuyerId,
                CandyId = model.CandyId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = JobStatus.Принят
            });
        }
        public void TakeOrderInWork(JobBindingModel model)
        {
            Job element = source.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != JobStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var candyMaterials = source.CandyMaterials.Where(rec => rec.CandyId == element.CandyId);
            foreach (var candyMaterial in candyMaterials)
            {
                int countOnStores = source.StoreMaterials
                .Where(rec => rec.MaterialId ==
                candyMaterial.MaterialId)
                .Sum(rec => rec.Count);
                if (countOnStores < candyMaterial.Count * element.Count)
                {
                    var MaterialName = source.Materials.FirstOrDefault(rec => rec.Id ==
                    candyMaterial.MaterialId);
                    throw new Exception("Не достаточно компонента " +
                    MaterialName?.MaterialName + " требуется " + (candyMaterial.Count * element.Count) +
                    ", в наличии " + countOnStores);
                }
            }
            // списываем
            foreach (var candyMaterial in candyMaterials)
            {
                int countOnStores = candyMaterial.Count * element.Count;
                var storeMaterials = source.StoreMaterials.Where(rec => rec.MaterialId
                == candyMaterial.MaterialId);
                foreach (var storeMaterial in storeMaterials)
                {
                    // компонентов на одном слкаде может не хватать
                    if (storeMaterial.Count >= countOnStores)
                    {
                        storeMaterial.Count -= countOnStores;
                        break;
                    }
                    else
                    {
                        countOnStores -= storeMaterial.Count;
                        storeMaterial.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = JobStatus.Выполняется;
        }
        public void FinishOrder(JobBindingModel model)
        {
            Job element = source.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != JobStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = JobStatus.Готов;
        }
        public void PayOrder(JobBindingModel model)
        {
            Job element = source.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != JobStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = JobStatus.Оплачен;
        }
        public void PutMaterialInStore(StoreMaterialBindingModel model)
        {
            StoreMaterial element = source.StoreMaterials.FirstOrDefault(rec => rec.StoreId == model.StoreId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StoreMaterials.Count > 0 ? source.StoreMaterials.Max(rec => rec.Id) : 0;
                source.StoreMaterials.Add(new StoreMaterial
                {
                    Id = ++maxId,
                    StoreId = model.StoreId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
        }
    }
}
