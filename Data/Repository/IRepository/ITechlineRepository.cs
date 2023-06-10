using MyAppointment.Models;

namespace MyAppointment.Data.Repository.IRepository
{
    public interface ITechLineRepository : IRepository<Techline>
    {
        void Update(Techline obj);
    }
}
