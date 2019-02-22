namespace AbstractSweetShopServiceDAL.ViewModels
{
    public class CandyMaterialViewModel
    {
        public int Id { get; set; }
        public int CandyId { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Count { get; set; }
    }
}
