using BoshAPI.Buisness_Logic.Exceptions;
using BoshAPI.Buisness_Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoshAPI.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) { _cartService = cartService; }

        [HttpPost("/api/cart/add")]
        public async Task<IActionResult> AddItemToCart(int id)
        {
            try
            {
                var result = await _cartService.AddChartItem(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("/api/cart")]
        public async Task<IActionResult> GetAllCartItems()
        {
            var result = await _cartService.GetAllCartItems();
            return Ok(result);
        }

        [HttpDelete("/api/cart/item/{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            try
            {
                var result = await _cartService.DeleteCartItem(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
