using BoshAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoshAPI.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _context.FindAsync<T>(id);
            return data;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public void Update(T entity)
        {

            _context.Entry(entity).State = EntityState.Modified;

        }


    }
}
