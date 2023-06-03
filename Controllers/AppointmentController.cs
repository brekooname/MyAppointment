﻿using Microsoft.AspNetCore.Mvc;
using MyAppointment.Services;
using MyAppointment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.TechnicianList = _appointmentService.GetTechnicianList();
            ViewBag.CustomerList = _appointmentService.GetCustomerList();
            return View();
        }
    }
}
