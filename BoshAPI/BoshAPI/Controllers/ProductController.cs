using BoshAPI.Buisness_Logic.Exceptions;
using BoshAPI.Buisness_Logic.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BoshAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        { _productService = productService; }

        [HttpGet("api/products")]
        public async Task<IActionResult> GetAllProductsPagination(int page, int pageSize)
        {
            var reslut = await _productService.GetProductsPaginationDto(page, pageSize);
            return Ok(reslut);
        }

        [HttpGet("api/products/{id}")]
        public async Task<IActionResult> GetProductWithId(int id)
        {
            try
            {
                var result = await _productService.GetProduct(id);

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
