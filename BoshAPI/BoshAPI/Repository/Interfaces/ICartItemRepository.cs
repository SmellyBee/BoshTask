using BoshAPI.Entities;

namespace BoshAPI.Repository.Interfaces
{
    public interface ICartItemRepository:IBaseRepository<CartItem>
    {
        Task<CartItem> GetSpecificCardItem(int cartId,int productId);
        Task<List<CartItem>> GetAllItemsOfSpecificCart(int id);
    }
}
