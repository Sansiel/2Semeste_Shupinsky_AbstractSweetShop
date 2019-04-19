using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class JobViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int BuyerId { get; set; }

        [DataMember]
        public string BuyerFIO { get; set; }

        [DataMember]
        public int CandyId { get; set; }

        [DataMember]
        public string CandyName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string DateCreate { get; set; }

        [DataMember]
        public string DateImplement { get; set; }
    }
}
