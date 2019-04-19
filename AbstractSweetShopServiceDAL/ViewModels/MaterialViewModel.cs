using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class MaterialViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string MaterialName { get; set; }
    }
}
