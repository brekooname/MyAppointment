using MyAppointment.Data;
using MyAppointment.Models.ViewModels;
using MyAppointment.Utility;
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
                           join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                           join roles in _context.Roles.Where(x => x.Name == Helper.Doctor) on userRoles.RoleId equals roles.Id
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
            var patients = (from user in _context.Users
                            join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                            join roles in _context.Roles.Where(x => x.Name == Helper.Patient) on userRoles.RoleId equals roles.Id
                            select new PatientVM
                            {
                                Id = user.Id,
                                Name = user.Name
                            }
                         ).ToList();

            return patients;
        }
    }
}
