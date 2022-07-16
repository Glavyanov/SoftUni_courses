namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Models;
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
                
        }
    }
}
