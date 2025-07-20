using BoshAPI.Entities;
using BoshAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BoshAPI.Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductWithDetailsById(int id)
        {
            var result = await _context.Products
                    .Include(p => p.Images)
                    .Include(p => p.TechsSpec)
                    .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }
    }
}
