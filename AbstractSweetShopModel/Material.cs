using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AbstractSweetShopModel

{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string MaterialName { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<StoreMaterial> StoreMaterials { get; set; }
        [ForeignKey("MaterialId")]
        public virtual List<CandyMaterial> CandyMaterials { get; set; }
    }
}
