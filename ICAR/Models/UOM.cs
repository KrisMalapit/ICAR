using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICAR.Models
{
    public class UOM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        [StringLength(20)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public string Status { get; set; } = "Active";
        

    }
}
