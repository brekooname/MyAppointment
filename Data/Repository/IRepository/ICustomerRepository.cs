using MyAppointment.Models;

namespace MyAppointment.Data.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
    }
}
