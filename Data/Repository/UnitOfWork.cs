using MyAppointment.Data.Repository.IRepository;

namespace MyAppointment.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IPartRepository Part { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Part = new PartRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
