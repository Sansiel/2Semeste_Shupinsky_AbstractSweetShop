using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class BuyerViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BuyerFIO { get; set; }
    }
}
