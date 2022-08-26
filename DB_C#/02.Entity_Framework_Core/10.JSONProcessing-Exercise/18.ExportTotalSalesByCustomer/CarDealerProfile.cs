using System.Linq;
using System.Globalization;

using AutoMapper;

using CarDealer.Models;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Parts;
using CarDealer.DTO.Sales;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Suppliers;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Suppliers
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(dest => dest.PartsCount, mo => mo.MapFrom(s => s.Parts.Count));

            //Parts
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<Part, ExportPartInfoDto>()
                .ForMember(dest => dest.Price, mo => mo.MapFrom(s => s.Price.ToString("F2")));

            //Customers
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dest => dest.BirthDate, mo => mo.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            //Sales
            this.CreateMap<ImportSalesDto, Sale>();

            //Cars
            this.CreateMap<Car, ExportToyotaCarsDto>();
            this.CreateMap<Car, ExportCarInfoDto>();

            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Car, mo => mo.MapFrom(d => d))
                .ForMember(dest => dest.Parts, mo => mo.MapFrom(s => s.PartCars.Select(x => x.Part)));
        }
    }
}
