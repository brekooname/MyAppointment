namespace MyAppointment.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IWorkTypeRepository WorkType { get; }
        IWorkOrderRepository WorkOrder { get; }
        void Save();
    }
}
