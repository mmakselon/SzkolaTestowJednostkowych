namespace SzkolaTestowJednostkowych.Mocking
{
    public interface IUnitOfWork
    {
        ITaskRepository Task { get; }
        void Complete();
    }
}
