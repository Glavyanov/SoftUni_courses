using AutoMapper;
using CarDealer.CarDealerDtos.Exports;
using CarDealer.CarDealerDtos.Imports;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(dest => dest.PartsCount, mo => mo.MapFrom(s => s.Parts.Count));

            //Part
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<Part, ExportPartDto>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dest => dest.TravelledDistance, mo => mo.MapFrom(s => s.TraveledDistance));
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportCarMakeDto>();
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(dest => dest.Parts, mo => mo.MapFrom(s => s.PartCars.Select(x => x.Part).OrderByDescending(x => x.Price)));

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dest => dest.BoughtCars, mo => mo.MapFrom(s => s.Sales.Count))
                .ForMember(dest => dest.SpentMoney,
                mo => mo.MapFrom(s => s.Sales.SelectMany(x => x.Car.PartCars).Sum(x => x.Part.Price)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();

        }
    }
}
