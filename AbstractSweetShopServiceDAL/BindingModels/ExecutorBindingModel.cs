using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class ExecutorBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ExecutorFIO { get; set; }
    }
}