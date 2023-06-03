using MyAppointment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Services
{
    public interface IAppointmentService
    {
        public List<TechnicianVM> GetTechnicianList();
        public List<CustomerVm> GetCustomerList();
        public Task<int> AddUpdate(AppointmentVM model);

        public List<AppointmentVM> TechniciansEventsById(string technicianId);

        public List<AppointmentVM> CustomersEventsById(string customerId);

        public AppointmentVM GetById(int id);

        public Task<int> Delete(int id);

        public Task<int> ConfirmEvent(int id);
    }
}
