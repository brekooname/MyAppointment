namespace MyAppointment.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPartRepository Part { get; }
        IWorkTypeRepository WorkType { get; }
        IWorkOrderRepository WorkOrder { get; }
        ITechLineRepository Techline { get; }
        void Save();
    }
}
