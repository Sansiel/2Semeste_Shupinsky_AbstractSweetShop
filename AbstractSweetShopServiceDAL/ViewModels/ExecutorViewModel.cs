using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class ExecutorViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ExecutorFIO { get; set; }
    }
}
