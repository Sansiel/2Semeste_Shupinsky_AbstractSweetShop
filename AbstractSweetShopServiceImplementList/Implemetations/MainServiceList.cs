using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

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
            List<JobViewModel> result = new List<JobViewModel>();
            for (int i = 0; i < source.Jobs.Count; ++i)
            {
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Buyers.Count; ++j)
                {
                    if (source.Buyers[j].Id == source.Jobs[i].BuyerId)
                    {
                        clientFIO = source.Buyers[j].BuyerFIO;
                        break;
                    }
                }
                string CandyName = string.Empty;
                for (int j = 0; j < source.Candies.Count; ++j)
                {
                    if (source.Candies[j].Id == source.Jobs[i].CandyId)
                    {
                        CandyName = source.Candies[j].CandyName;
                        break;
                    }
                }
                result.Add(new JobViewModel
                {
                    Id = source.Jobs[i].Id,
                    BuyerId = source.Jobs[i].BuyerId,
                    BuyerFIO = clientFIO,
                    CandyId = source.Jobs[i].CandyId,
                    CandyName = CandyName,
                    Count = source.Jobs[i].Count,
                    Sum = source.Jobs[i].Sum,
                    DateCreate = source.Jobs[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Jobs[i].DateImplement?.ToLongDateString(),
                    Status = source.Jobs[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateOrder(JobBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Jobs.Count; ++i)
            {
                if (source.Jobs[i].Id > maxId)
                {
                    maxId = source.Buyers[i].Id;
                }
            }
            source.Jobs.Add(new Job
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
            int index = -1;
            for (int i = 0; i < source.Jobs.Count; ++i)
            {
                if (source.Jobs[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Jobs[index].Status != JobStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Jobs[index].DateImplement = DateTime.Now;
            source.Jobs[index].Status = JobStatus.Выполняется;
        }
        public void FinishOrder(JobBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Jobs.Count; ++i)
            {
                if (source.Buyers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Jobs[index].Status != JobStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Jobs[index].Status = JobStatus.Готов;
        }
        public void PayOrder(JobBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Jobs.Count; ++i)
            {
                if (source.Buyers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Jobs[index].Status != JobStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Jobs[index].Status = JobStatus.Оплачен;
        }
    }
}
