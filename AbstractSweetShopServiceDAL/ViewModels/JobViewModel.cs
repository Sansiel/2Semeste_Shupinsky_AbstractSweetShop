namespace AbstractSweetShopServiceDAL.ViewModels
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string BuyerFIO { get; set; }
        public int CandyId { get; set; }
        public string CandyName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string DateImplement { get; set; }
    }
}
