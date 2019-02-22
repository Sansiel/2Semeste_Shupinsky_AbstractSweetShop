﻿using AbstractSweetShopModel;
using System.Collections.Generic;

namespace AbstractSweetShopServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Material> Materials { get; set; }
        public List<Order> Orders { get; set; }
        public List<Candy> Candies { get; set; }
        public List<CandyMaterial> CandyMaterials { get; set; }
        private DataListSingleton()
        {
            Clients = new List<Client>();
			Materials = new List<Material>();
            Orders = new List<Order>();
			Candies = new List<Candy>();
			CandyMaterials = new List<CandyMaterial>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
