namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using System;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>();

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(dest => dest.PositionId, src => src.MapFrom(p => p.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(dest => dest.Position, src => src.MapFrom(p => p.Position.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(dest => dest.CategoryId, src => src.MapFrom(p => p.Id));
            this.CreateMap<CreateItemInputModel, Item>();
            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(dest => dest.Category, src => src.MapFrom(p => p.Category.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember( dest => dest.Name, src => src.MapFrom(p => p.CategoryName));
            this.CreateMap<Category, CategoryAllViewModel>();

            //Orders
            this.CreateMap<Item, CreateItemViewModel>()
                .ForMember(dest => dest.CategoryId, src => src.MapFrom(p => p.Id));
            this.CreateMap<Employee, RegisterEmployeeViewModel>()
                .ForMember(dest => dest.PositionId, src => src.MapFrom(p => p.Id));
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(dest => dest.DateTime, src => src.MapFrom(p => DateTime.Now));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(dest => dest.OrderId, src => src.MapFrom(p => p.Id))
                .ForMember(dest => dest.Employee, src => src.MapFrom(p => p.Employee.Name))
                .ForMember(dest => dest.DateTime , src => src.MapFrom(p => p.DateTime.ToString("F")));
                
        }
    }
}
