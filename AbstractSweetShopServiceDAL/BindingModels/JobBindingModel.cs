namespace AbstractSweetShopServiceDAL.BindingModels
{
    public class JobBindingModel
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int CandyId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
