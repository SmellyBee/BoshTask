using BoshAPI.Buisness_Logic.DTO;

namespace BoshAPI.Buisness_Logic.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<CardItemDto>> GetProductsPaginationDto(int page, int pageSize);
        Task<ProductDetailedInfoDto> GetProduct(int id);
    }
}
