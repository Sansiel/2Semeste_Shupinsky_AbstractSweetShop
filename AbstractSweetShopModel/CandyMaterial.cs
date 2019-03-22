namespace AbstractSweetShopModel
{
    public class CandyMaterial
    {
        public int Id { get; set; }
        public int CandyId { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Count { get; set; }
        public virtual Material Material { get; set; }
        public virtual Candy Candy { get; set; }
    }
}
