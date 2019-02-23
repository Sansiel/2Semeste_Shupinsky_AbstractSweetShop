using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopServiceImplementList.Implemetations
{
    public class BuyerServiceList : IBuyerService
    {
        private DataListSingleton source;

        public BuyerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<BuyerViewModel> GetList()
        {
            List<BuyerViewModel> result = source.Buyers.Select(rec => new BuyerViewModel
            {
                Id = rec.Id,
                BuyerFIO = rec.BuyerFIO
            }).ToList();
            return result;
        }

        public BuyerViewModel GetElement(int id)
        {
            Buyer element = source.Buyers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BuyerViewModel
                {
                    Id = element.Id,
                    BuyerFIO = element.BuyerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BuyerBindingModel model)
        {
            Buyer element = source.Buyers.FirstOrDefault(rec => rec.BuyerFIO == model.BuyerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Buyers.Count > 0 ? source.Buyers.Max(rec => rec.Id) : 0;
            source.Buyers.Add(new Buyer { Id = maxId + 1, BuyerFIO = model.BuyerFIO });
        }

        public void UpdElement(BuyerBindingModel model)
        {
            Buyer element = source.Buyers.FirstOrDefault(rec => rec.BuyerFIO == model.BuyerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Buyers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BuyerFIO = model.BuyerFIO;
        }

        public void DelElement(int id)
        {
            Buyer element = source.Buyers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Buyers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
