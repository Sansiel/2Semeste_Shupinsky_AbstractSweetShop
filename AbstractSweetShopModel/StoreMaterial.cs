namespace AbstractSweetShopModel
{
    public class StoreMaterial
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
        public virtual Material Material { get; set; }
        public virtual Store Store { get; set; }
    }
}
