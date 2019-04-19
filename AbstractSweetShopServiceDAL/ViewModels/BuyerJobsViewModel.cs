using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class BuyerJobsViewModel
    {
        [DataMember]
        public string BuyerName { get; set; }

        [DataMember]
        public string DateCreate { get; set; }

        [DataMember]
        public string CandyName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
