using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAppointment.Models
{
    public class WorkOrder
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
        public DateTime ReturnDate { get; set; }
        public bool StatusOfWorkOrder { get; set; }

        [Required]
        [Display(Name = "Work Type")]
        public int WorkTypeId { get; set; }
        [ForeignKey("WorkTypeId")]
        [ValidateNever]
        public WorkType WorkType { get; set; }
    }
}
