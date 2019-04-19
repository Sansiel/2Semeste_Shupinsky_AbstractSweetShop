using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    [DataContract]
    public class MaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string MaterialName { get; set; }
    }
}
