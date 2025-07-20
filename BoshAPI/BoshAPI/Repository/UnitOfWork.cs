namespace BoshAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
