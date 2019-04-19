using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class CandyBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CandyName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<CandyMaterialBindingModel> CandyMaterials { get; set; }
    }
}
