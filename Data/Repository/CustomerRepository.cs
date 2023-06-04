using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Customer obj)
        {
            _db.Customers.Update(obj);
        }
    }
}
