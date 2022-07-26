using AutoMapper;
using ProductShop.DTOs.ExportDTOs;
using ProductShop.DTOs.ImportDTOs;
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
            this.CreateMap<User, ExportUserWithSoldProductsDto>()
                .ForMember(dest => dest.SoldProducts,
                mo => mo.MapFrom(src => src.ProductsSold.Where(p => p.BuyerId.HasValue)));

            //Products
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(dest => dest.SellerName, 
                src => src.MapFrom(p => $"{p.Seller.FirstName} {p.Seller.LastName}"));
            this.CreateMap<Product, ExportSoldProductDto>()
                .ForMember(dest => dest.BuyerFirstName, mo => mo.MapFrom(src => src.Buyer.FirstName))
                .ForMember(dest => dest.BuyerLastName, mo => mo.MapFrom(src => src.Buyer.LastName));
                

            //Categories
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<Category, ExportCategoryByProductDto>()
                .ForMember(dest => dest.Count, mo => mo.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice,
                         mo => mo.MapFrom(src => $"{src.CategoryProducts.Average(p => p.Product.Price):F2}"))
                .ForMember(dest => dest.TotalRevenue, 
                         mo => mo.MapFrom(
                   src => $"{src.CategoryProducts.Sum(p => p.Product.Price):F2}"));

            //CategoryProducts
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
