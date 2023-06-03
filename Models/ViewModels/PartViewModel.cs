using System.ComponentModel.DataAnnotations;

namespace MyAppointment.Models.ViewModels
{
    public class PartViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(255)]
        public string PartNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string PartDescription { get; set; }

        public bool StatusOfWorkOrder { get; set; }
    }
}
