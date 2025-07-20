using AutoMapper;
using BoshAPI.Buisness_Logic.DTO;
using BoshAPI.Buisness_Logic.Exceptions;
using BoshAPI.Buisness_Logic.Interfaces;
using BoshAPI.Entities;
using BoshAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoshAPI.Buisness_Logic.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        protected readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper) 
        {   
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardItemDto>> GetProductsPaginationDto(int page, int pageSize)
        {
            var items = await _productRepository.GetAll()
                .Include(p => p.Images)
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mappItems = _mapper.Map<IEnumerable<CardItemDto>>(items);
            
            return mappItems;
        }

        public async Task<ProductDetailedInfoDto> GetProduct(int id)
        {
            
            var item = await _productRepository.GetProductWithDetailsById(id);
            if (item == null)
                throw new NotFoundException(nameof(Product), id);

            var mappedItem = _mapper.Map<ProductDetailedInfoDto>(item);
           
            return mappedItem;
        }
    }
}
