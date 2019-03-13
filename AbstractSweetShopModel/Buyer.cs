using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractSweetShopModel
{
    public class Buyer
    {
        public int Id { get; set; }

        [Required]
        public string BuyerFIO { get; set; }

        [ForeignKey("BuyerId")]
        public virtual List<Job> Jobs { get; set; }
    }
}
