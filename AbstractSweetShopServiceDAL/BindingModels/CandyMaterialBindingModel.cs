using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class CandyMaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CandyId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public string MaterialName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
