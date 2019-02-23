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
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Clients.Count; ++j)
                {
                    if (source.Clients[j].Id == source.Orders[i].BuyerId)
                    {
                        clientFIO = source.Clients[j].BuyerFIO;
                        break;
                    }
                }
                string CandyName = string.Empty;
                for (int j = 0; j < source.Candies.Count; ++j)
                {
                    if (source.Candies[j].Id == source.Orders[i].CandyId)
                    {
                        CandyName = source.Candies[j].CandyName;
                        break;
                    }
                }
                result.Add(new JobViewModel
                {
                    Id = source.Orders[i].Id,
                    BuyerId = source.Orders[i].BuyerId,
                    BuyerFIO = clientFIO,
                    CandyId = source.Orders[i].CandyId,
                    CandyName = CandyName,
                    Count = source.Orders[i].Count,
                    Sum = source.Orders[i].Sum,
                    DateCreate = source.Orders[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Orders[i].DateImplement?.ToLongDateString(),
                    Status = source.Orders[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateOrder(JobBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id > maxId)
                {
                    maxId = source.Clients[i].Id;
                }
            }
            source.Orders.Add(new Job
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
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != JobStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Orders[index].DateImplement = DateTime.Now;
            source.Orders[index].Status = JobStatus.Выполняется;
        }
        public void FinishOrder(JobBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != JobStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Orders[index].Status = JobStatus.Готов;
        }
        public void PayOrder(JobBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != JobStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Orders[index].Status = JobStatus.Оплачен;
        }
    }
}
