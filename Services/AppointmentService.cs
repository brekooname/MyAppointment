using MyAppointment.Data;
using MyAppointment.Models;
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

        public async Task<int> AddUpdate(AppointmentVM model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));
            var customer = _context.Users.FirstOrDefault(u => u.Id == model.CustomerId);
            var technician = _context.Users.FirstOrDefault(u => u.Id == model.TechnicianId);

            if (model != null && model.Id > 0)
            {
                var appointment = _context.Appointments.FirstOrDefault(x => x.Id == model.Id);
                appointment.Title = model.Title;
                appointment.Description = model.Description;
                appointment.StartDate = startDate;
                appointment.EndDate = endDate;
                appointment.Duration = model.Duration;
                appointment.TechnicianId = model.TechnicianId;
                appointment.CustomerId = model.CustomerId;
                appointment.IsTechnicianApproved = false;
                appointment.AdminId = model.AdminId;
                await _context.SaveChangesAsync();
                //update
                return 1;
            }
            else
            {
                //create
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    TechnicianId = model.TechnicianId,
                    CustomerId = model.CustomerId,
                    IsTechnicianApproved = false,
                    AdminId = model.AdminId
                };

                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return 2;
            }

        }

        public async Task<int> ConfirmEvent(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment != null)
            {
                appointment.IsTechnicianApproved = true;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public List<AppointmentVM> TechniciansEventsById(string technicianId)
        {
            return _context.Appointments.Where(x => x.TechnicianId == technicianId).ToList().Select(c => new AppointmentVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsTechnicianApproved = c.IsTechnicianApproved
            }).ToList();
        }

        public AppointmentVM GetById(int id)
        {
            return _context.Appointments.Where(x => x.Id == id).ToList().Select(c => new AppointmentVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsTechnicianApproved = c.IsTechnicianApproved,
                CustomerId = c.CustomerId,
                TechnicianId = c.TechnicianId,
                CustomerName = _context.Users.Where(x => x.Id == c.CustomerId).Select(x => x.Name).FirstOrDefault(),
                TechnicianName = _context.Users.Where(x => x.Id == c.TechnicianId).Select(x => x.Name).FirstOrDefault(),
            }).SingleOrDefault();
        }

        public List<TechnicianVM> GetTechnicianList()
        {
            var technicians = (from user in _context.Users
                           join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                           join roles in _context.Roles.Where(x => x.Name == Helper.Technician) on userRoles.RoleId equals roles.Id
                           select new TechnicianVM
                           {
                               Id = user.Id,
                               Name = user.Name
                           }
                          ).ToList();

            return technicians;
        }

        public List<CustomerVM> GetCustomerList()
        {
            var customers = (from user in _context.Users
                            join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                            join roles in _context.Roles.Where(x => x.Name == Helper.Customer) on userRoles.RoleId equals roles.Id
                            select new CustomerVM
                            {
                                Id = user.Id,
                                Name = user.Name
                            }
                         ).ToList();

            return customers;
        }

        public List<AppointmentVM> CustomersEventsById(string customerId)
        {
            return _context.Appointments.Where(x => x.CustomerId == customerId).ToList().Select(c => new AppointmentVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsTechnicianApproved = c.IsTechnicianApproved
            }).ToList();
        }
    }
}
