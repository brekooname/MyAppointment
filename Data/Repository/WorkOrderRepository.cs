using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public WorkOrderRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(WorkOrder obj)
        {
            _db.WorkOrders.Update(obj);
        }
    }
}
