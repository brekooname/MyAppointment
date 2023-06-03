using MyAppointment.Models;

namespace MyAppointment.Data.Repository.IRepository
{
    public interface IPartRepository : IRepository<Part>
    {
        void Update(Part obj);
    }
}
