using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AbstractSweetShopModel
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        public string StoreName { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<StoreMaterial> StoreMaterials { get; set; }
    }
}
