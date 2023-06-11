namespace MyAppointment.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPartRepository Part { get; }
        IWorkTypeRepository WorkType { get; }
        IWorkOrderRepository WorkOrder { get; }
        ITechLineRepository Techline { get; }
        IWarrantyRepository Warranty { get; }
        void Save();
    }
}
