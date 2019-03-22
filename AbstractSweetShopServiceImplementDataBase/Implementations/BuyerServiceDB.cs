using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AbstractSweetShopServiceImplementDataBase.Implementations
{
    public class BuyerServiceDB : IBuyerService
    {
        private AbstractDbContext context;
        public BuyerServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<BuyerViewModel> GetList()
        {
            List<BuyerViewModel> result = context.Buyers.Select(rec => new
            BuyerViewModel
            {
                Id = rec.Id,
                BuyerFIO = rec.BuyerFIO
            })
            .ToList();
            return result;
        }
        public BuyerViewModel GetElement(int id)
        {
            Buyer element = context.Buyers.FirstOrDefault(rec => rec.Id == id);
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
            Buyer element = context.Buyers.FirstOrDefault(rec => rec.BuyerFIO ==
            model.BuyerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Buyers.Add(new Buyer
            {
                BuyerFIO = model.BuyerFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(BuyerBindingModel model)
        {
            Buyer element = context.Buyers.FirstOrDefault(rec => rec.BuyerFIO ==
            model.BuyerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Buyers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BuyerFIO = model.BuyerFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Buyer element = context.Buyers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Buyers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}