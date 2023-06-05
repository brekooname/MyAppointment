using MyAppointment.Models;

namespace MyAppointment.Data.Repository.IRepository
{
    public interface IWorkTypeRepository : IRepository<WorkType>
    {
        void Update(WorkType obj);
    }
}
