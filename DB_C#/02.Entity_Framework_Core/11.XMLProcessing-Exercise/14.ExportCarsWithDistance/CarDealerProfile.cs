using AutoMapper;
using CarDealer.CarDealerDtos.Exports;
using CarDealer.CarDealerDtos.Imports;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Part
            this.CreateMap<ImportPartDto, Part>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dest => dest.TravelledDistance, mo => mo.MapFrom(s => s.TraveledDistance));
            this.CreateMap<Car, ExportCarDto>();

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();

        }
    }
}
