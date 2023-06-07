﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyAppointment.Models.ViewModels
{
    public class PartViewModel
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
        [Range(0, 20)]
        public byte NumberInStock { get; set; }
        public decimal PartPrice { get; set; }

    }
}
