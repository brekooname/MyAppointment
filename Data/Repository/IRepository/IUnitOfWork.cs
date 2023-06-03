namespace MyAppointment.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPartRepository Part { get; }
        void Save();
    }
}
