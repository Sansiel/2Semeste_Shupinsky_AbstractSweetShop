using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    public class CandyViewModel
    {
        public int Id { get; set; }
        public string CandyName { get; set; }
        public decimal Price { get; set; }
        public List<CandyMaterialViewModel> CandyMaterials { get; set; }
    }
}
