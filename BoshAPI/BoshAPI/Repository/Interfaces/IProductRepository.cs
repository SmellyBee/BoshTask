using BoshAPI.Entities;

namespace BoshAPI.Repository.Interfaces
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<Product> GetProductWithDetailsById(int id);
    }
}
