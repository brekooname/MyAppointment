using MyAppointment.Models;

namespace MyAppointment.Data.Repository.IRepository
{
    public interface IWorkOrderRepository : IRepository<WorkOrder>
    {
        void Update(WorkOrder obj);
    }
}
