using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAppointment.Models.ViewModels
{
    public class WorkOrderViewModel
    {
        public WorkOrder WorkOrder { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> WorkTypeList { get; set; }
    }
}
