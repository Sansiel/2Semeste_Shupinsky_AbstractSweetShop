using AbstractSweetShopModel;
using System.Collections.Generic;

namespace AbstractSweetShopServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Buyer> Buyers { get; set; }
        public List<Material> Materials { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Candy> Candies { get; set; }
        public List<CandyMaterial> CandyMaterials { get; set; }
        public List<Store> Stores { get; set; }
        public List<StoreMaterial> StoreMaterials { get; set; }
        private DataListSingleton()
        {
            Buyers = new List<Buyer>();
			Materials = new List<Material>();
            Jobs = new List<Job>();
			Candies = new List<Candy>();
			CandyMaterials = new List<CandyMaterial>();
            Stores = new List<Store>();
            StoreMaterials = new List<StoreMaterial>();
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
