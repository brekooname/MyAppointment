using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        private readonly ApplicationDbContext _db;

        public PartRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Part obj)
        {
            _db.Parts.Update(obj);
        }
    }
}
