using AutoMapper;
using ProductShop.DTOs.ImportDTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
        }
    }
}
