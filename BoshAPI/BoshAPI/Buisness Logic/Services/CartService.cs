using AutoMapper;
using BoshAPI.Buisness_Logic.DTO;
using BoshAPI.Buisness_Logic.Exceptions;
using BoshAPI.Buisness_Logic.Interfaces;
using BoshAPI.Entities;
using BoshAPI.Repository;
using BoshAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BoshAPI.Buisness_Logic.Services
{
    public class CartService:ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository,ICartItemRepository cartItemRepository,
            IMapper mapper,IProductRepository productRepository,IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<string> AddChartItem(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException(nameof(Product), id);

            var cart = await _cartRepository.GetByIdAsync(1);
            if (product == null)
                throw new NotFoundException(nameof(Cart), id);

            cart.Check += product.Price;

            _cartRepository.Update(cart);

            var cartItem = await _cartItemRepository.GetSpecificCardItem(cart.Id, product.Id);
            if(cartItem == null)
            {
                var cartItemNew = new CartItem
                {
                    Cart = cart,
                    Product = product,
                    Quantity = 1,
                };

                await _cartItemRepository.AddAsync(cartItemNew);
                await _unitOfWork.Commit();
                
                return "New item added to cart";
            }

            cartItem.Quantity++;

            _cartItemRepository.Update(cartItem);
            await _unitOfWork.Commit();

            return "New item added to cart";

        }

        public async Task<List<CartItemDto>> GetAllCartItems()
        {
            var cartItems = await _cartItemRepository.GetAllItemsOfSpecificCart(1);
            
            var result = _mapper.Map<List<CartItemDto>>(cartItems);

            return result;

        }

        public async Task<string> DeleteCartItem(int id)
        {
            var cartItem = await _cartItemRepository.GetSpecificCardItem(1, id);
            if (cartItem == null)
            {
                throw new NotFoundException(nameof(CartItem), id);
            }
           
            cartItem.Quantity--;

            if(cartItem.Quantity == 0)
            {
                _cartItemRepository.Delete(cartItem);
                
            }
            else { _cartItemRepository.Update(cartItem); }

            await _unitOfWork.Commit();
            return $"{nameof(DeleteCartItem)}";

        }
    }
}
