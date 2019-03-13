using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractSweetShopModel
{
    public class Candy
    {
        public int Id { get; set; }

        [Required]
        public string CandyName { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CandyId")]
        public virtual List<Job> Jobs  { get; set; }
    }
}
