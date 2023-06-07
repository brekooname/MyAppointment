using System.ComponentModel.DataAnnotations;

namespace MyAppointment.Models
{
    public class Techline
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }

        [Display(Name ="Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
