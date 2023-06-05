using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class WorkTypeRepository : Repository<WorkType>, IWorkTypeRepository
    {
        private ApplicationDbContext _db;

        public WorkTypeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(WorkType obj)
        {
            _db.WorkTypes.Update(obj);
        }
    }
}
