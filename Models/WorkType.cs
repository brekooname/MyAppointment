using System.ComponentModel.DataAnnotations;

namespace MyAppointment.Models
{
    public class WorkType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
