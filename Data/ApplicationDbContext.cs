using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<WorkType> WorkTypes { get; set; }

        public DbSet<Techline> Techlines { get; set; }
    }
}
