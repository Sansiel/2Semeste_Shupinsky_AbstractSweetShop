using System.ComponentModel;

namespace AbstractSweetShopServiceDAL.ViewModels
{
    public class StoreMaterialViewModel
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int MaterialId { get; set; }

        [DisplayName("Название компонента")]
        public string MaterialName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
