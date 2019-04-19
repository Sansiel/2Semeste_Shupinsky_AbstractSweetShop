using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    [DataContract]
    public class StoreViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название склада")]
        public string StoreName { get; set; }

        [DataMember]
        public List<StoreMaterialViewModel> StoreMaterials { get; set; }
    }
}
