using BoshAPI.Entities;
using BoshAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoshAPI.Repository.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _context;
        public CartItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CartItem> GetSpecificCardItem(int cartId, int productId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(cart => cart.CartId == cartId && cart.ProductId == productId);
        }

        public async Task<List<CartItem>> GetAllItemsOfSpecificCart(int id)
        {
            return await _context.CartItems
                .Where(cart => cart.CartId == id)
                .Include(p => p.Product).ThenInclude(p => p.Images)
                .ToListAsync();
        }
    }
}
