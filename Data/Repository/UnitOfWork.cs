using MyAppointment.Data.Repository.IRepository;

namespace MyAppointment.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICustomerRepository Customer { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
