using AutoMapper;
using BoshAPI.Buisness_Logic.DTO;
using BoshAPI.Entities;

namespace BoshAPI.Buisness_Logic.ProfileMappers
{
    public class CartMapper : Profile
    {
        public CartMapper() {

            CreateMap<Product, CardItemDto>().ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
            src.Images != null && src.Images.Count > 1 ? src.Images[0].Name : null
            )).ReverseMap();

            CreateMap<CartItem,CartItemDto>()
                .ForMember(dest => dest.ProductInfo, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();
        }
    }
}
