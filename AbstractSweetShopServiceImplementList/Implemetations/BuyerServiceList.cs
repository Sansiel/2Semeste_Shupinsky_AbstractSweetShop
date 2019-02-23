using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopServiceImplementList.Implemetations
{
    public class BuyerServiceList : IBuyerService
    {
        private DataListSingleton source;

        public BuyerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(BuyerBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id > maxId)
                {
                    maxId = source.Clients[i].Id;
                }
                if (source.Clients[i].BuyerFIO == model.BuyerFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Clients.Add(new Buyer
            {
                Id = maxId + 1,
                BuyerFIO = model.BuyerFIO
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == id)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public BuyerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == id)
                {
                    return new BuyerViewModel
                    {
                        Id = source.Clients[i].Id,
                        BuyerFIO = source.Clients[i].BuyerFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<BuyerViewModel> GetList()
        {
            List<BuyerViewModel> result = new List<BuyerViewModel>();
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                result.Add(new BuyerViewModel
                {
                    Id = source.Clients[i].Id,
                    BuyerFIO = source.Clients[i].BuyerFIO
                });
            }
            return result;
        }

        public void UpdElement(BuyerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Clients[i].BuyerFIO == model.BuyerFIO &&
                source.Clients[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Clients[index].BuyerFIO = model.BuyerFIO;
        }
    }
}
