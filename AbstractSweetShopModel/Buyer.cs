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

        public string Mail { get; set; }

        [ForeignKey("BuyerId")]
        public virtual List<Job> Jobs { get; set; }

        [ForeignKey("BuyerId")]
        public virtual List<MessageInfo> MessageInfos { get; set; }
    }
}
