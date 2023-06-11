using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;

namespace MyAppointment.Data.Repository
{
    public class WarrantyRepository : Repository<Warranty>, IWarrantyRepository
    {
        private readonly ApplicationDbContext _db;

        public WarrantyRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void Update(Warranty obj)
        {
            _db.Warranties.Update(obj);
        }
    }
}
