using BoshAPI.Buisness_Logic.DTO;

namespace BoshAPI.Buisness_Logic.Interfaces
{
    public interface ICartService
    {
        Task<string> AddChartItem(int id); 
        Task<List<CartItemDto>> GetAllCartItems();

        Task<string> DeleteCartItem(int id);
    }
}
