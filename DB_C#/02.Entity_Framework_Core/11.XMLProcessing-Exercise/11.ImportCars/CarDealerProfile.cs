using AutoMapper;
using CarDealer.CarDealerDtos;
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

            //Part
            this.CreateMap<ImportPartDto, Part>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dest => dest.TravelledDistance, mo => mo.MapFrom(s => s.TraveledDistance));
        }
    }
}
