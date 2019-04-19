using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class CandyViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CandyName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<CandyMaterialViewModel> CandyMaterials { get; set; }
    }
}
