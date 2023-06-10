using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IWorkOrderRepository WorkOrder { get; private set; }

        public IWorkTypeRepository WorkType { get; private set; }

        public IPartRepository Part { get; private set; }

        public ITechLineRepository Techline { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            WorkOrder = new WorkOrderRepository(_db);
            WorkType = new WorkTypeRepository(_db);
            Part = new PartRepository(_db);
            Techline = new TechLineRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
