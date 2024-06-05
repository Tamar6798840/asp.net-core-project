using AutoMapper;
using DTO;
using Entities;

namespace MySite
{
    public class Mapper:Profile
    {
      
        public Mapper()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName,
               opts => opts.MapFrom(src => src.Category.CategoryName)).ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemsDTO>().ReverseMap();
        }




    }
}
