using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Models.ViewModels
{
    public class CustomerVM
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
