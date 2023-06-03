﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string TechnicianId { get; set; }
        public string CustomerId { get; set; }
        public bool IsTechnicianApproved { get; set; }
        public string AdminId { get; set; }
    }
}
