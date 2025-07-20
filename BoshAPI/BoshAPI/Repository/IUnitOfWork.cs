namespace BoshAPI.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();

    }
}
