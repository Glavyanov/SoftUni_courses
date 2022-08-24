using AutoMapper;
using ProductShop.Dtos.Categories;
using ProductShop.Dtos.CategoryProducts;
using ProductShop.Dtos.Products;
using ProductShop.Dtos.Users;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Users
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportUserSoldProductsDto>()
                .ForMember(dest => dest.SoldProducts, mo => mo.MapFrom(src => src.ProductsSold));


            //Products
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(dest => dest.BuyerFullName, mo => mo.MapFrom(src => src.BuyerId.HasValue ?$"{src.Buyer.FirstName} {src.Buyer.LastName}" : null));
            this.CreateMap<Product, ExportProductSoldProductsDto>();

            //Categories
            this.CreateMap<ImportCategoryDto, Category>();

            //CategoryProducts
            this.CreateMap<ImportCategoryProductsDto, CategoryProduct>();
            this.CreateMap<Category, ExportCategoryDto>()
                .ForMember(dest => dest.Count, mo => mo.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice, mo => mo.MapFrom(src => src.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(dest => dest.TotalRevenue, mo =>
                    mo.MapFrom(src => src.CategoryProducts.Sum(e => e.Product.Price)));
        }
    }
}
