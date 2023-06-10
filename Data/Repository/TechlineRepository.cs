using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class TechLineRepository : Repository<Techline>, ITechLineRepository
    {
        private readonly ApplicationDbContext _db;

        public TechLineRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Techline obj)
        {
            _db.Techlines.Update(obj);
        }
    }
}
