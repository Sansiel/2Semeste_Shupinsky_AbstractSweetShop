﻿using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopServiceImplementDataBase.Implementations
{
    public class MaterialServiceDB : IMaterialService
    {
        private AbstractDbContext context;

        public MaterialServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void AddElement(MaterialBindingModel model)
        {
            Material element = context.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName);
            if (element != null)
            {
                throw new Exception("Уже есть материал с таким названием");
            }
            context.Materials.Add(new Material
            {
                MaterialName = model.MaterialName
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Material element = context.Materials.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Materials.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public MaterialViewModel GetElement(int id)
        {
            Material element = context.Materials.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new MaterialViewModel
                {
                    Id = element.Id,
                    MaterialName = element.MaterialName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<MaterialViewModel> GetList()
        {
            List<MaterialViewModel> result = context.Materials.Select(rec => new MaterialViewModel
            {
                Id = rec.Id,
                MaterialName = rec.MaterialName
            })
            .ToList();
            return result;
        }

        public void UpdElement(MaterialBindingModel model)
        {
            Material element = context.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть материал с таким названием");
            }
            element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.MaterialName = model.MaterialName;
            context.SaveChanges();
        }
    }
}