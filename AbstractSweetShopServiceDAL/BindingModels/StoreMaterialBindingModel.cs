namespace AbstractSweetShopServiceDAL.BindingModels
{
    public class StoreMaterialBindingModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}
