namespace BoshAPI.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        //Generic CRUD Operations

        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        void Delete(T entity);
        void Update(T entity);
    }
}
