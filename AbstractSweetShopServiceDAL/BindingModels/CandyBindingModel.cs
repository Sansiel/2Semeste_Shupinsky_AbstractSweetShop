using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    public class CandyBindingModel
    {
        public int Id { get; set; }
        public string CandyName { get; set; }
        public decimal Price { get; set; }
        public List<CandyMaterialBindingModel> CandyMaterials { get; set; }
    }
}
