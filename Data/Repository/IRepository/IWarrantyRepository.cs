using MyAppointment.Models;

namespace MyAppointment.Data.Repository.IRepository
{
    public interface IWarrantyRepository : IRepository<Warranty>
    {
        void Update(Warranty obj);
    }
}
