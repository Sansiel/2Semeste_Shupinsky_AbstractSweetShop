using System;

namespace AbstractSweetShopModel
{
    public class Job
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int CandyId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public JobStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Candy Candy { get; set; }
    }
}
