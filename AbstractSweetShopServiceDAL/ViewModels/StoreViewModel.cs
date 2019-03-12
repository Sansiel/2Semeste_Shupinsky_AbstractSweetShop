using System.ComponentModel;
using System.Collections.Generic;

namespace AbstractSweetShopServiceDAL.ViewModels
{

    public class StoreViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string StoreName { get; set; }

        public List<StoreMaterialViewModel> StoreMaterials { get; set; }
    }
}
