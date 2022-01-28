using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICAR.Models
{
    public class EquipmentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Dimension Code")]
        [Required]
        [StringLength(20)]
        public string DimensionCode { get; set; }
      
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public virtual Company Companies { get; set; }
        public string Status { get; set; } = "Active";
    }
}
