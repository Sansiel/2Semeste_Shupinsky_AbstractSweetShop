using AbstractSweetShopModel;
using System.Collections.Generic;

namespace AbstractSweetShopServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Buyer> Clients { get; set; }
        public List<Material> Materials { get; set; }
        public List<Job> Orders { get; set; }
        public List<Candy> Candies { get; set; }
        public List<CandyMaterial> CandyMaterials { get; set; }
        private DataListSingleton()
        {
            Clients = new List<Buyer>();
			Materials = new List<Material>();
            Orders = new List<Job>();
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
