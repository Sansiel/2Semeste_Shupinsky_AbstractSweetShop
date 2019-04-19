using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class BuyerBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BuyerFIO { get; set; }
    }
}
