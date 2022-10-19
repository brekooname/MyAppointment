using MyAppointment.Data;
using MyAppointment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<DoctorVM> GetDoctorList()
        {
            var doctors = (from user in _context.Users
                           select new DoctorVM
                           {
                               Id = user.Id,
                               Name = user.Name
                           }
                        ).ToList();

            return doctors;
        }

        public List<PatientVM> GetPatientList()
        {
            throw new NotImplementedException();
        }
    }
}
