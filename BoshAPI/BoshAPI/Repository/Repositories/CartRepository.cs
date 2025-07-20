using BoshAPI.Entities;
using BoshAPI.Repository.Interfaces;

namespace BoshAPI.Repository.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }
    }
}
