using MyAppointment.Data.Repository.IRepository;

namespace MyAppointment.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IWorkOrderRepository WorkOrder { get; private set; }

        public IWorkTypeRepository WorkType { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            WorkOrder = new WorkOrderRepository(_db);
            WorkType = new WorkTypeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
