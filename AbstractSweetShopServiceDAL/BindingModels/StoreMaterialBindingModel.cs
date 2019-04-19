using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class StoreMaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int StoreId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
