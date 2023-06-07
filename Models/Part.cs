using System.ComponentModel.DataAnnotations;

namespace MyAppointment.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PartName { get; set; }
        [Required]
        [StringLength(255)]
        public string PartNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string PartDescription { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(0,20)]
        public byte NumberInStock { get; set; }
        public decimal PartPrice { get; set; }

    }
}
