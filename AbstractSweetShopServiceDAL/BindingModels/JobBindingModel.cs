using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class JobBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int BuyerId { get; set; }

        [DataMember]
        public int CandyId { get; set; }

        [DataMember]
        public int? ExecutorId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}
