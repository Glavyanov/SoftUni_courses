using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Parts;
using CarDealer.DTO.Sales;
using CarDealer.DTO.Suppliers;
using CarDealer.Models;

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
                .ForMember(dest => dest.Name, mo => mo.MapFrom(s => s.Name))
                .ForMember(dest => dest.Price, mo => mo.MapFrom(s => s.Price.ToString("F2")));

            //Customers
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dest => dest.BirthDate, mo => mo.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            //Sales
            this.CreateMap<ImportSalesDto, Sale>();

            //Cars
            this.CreateMap<Car, ExportToyotaCarsDto>();
            this.CreateMap<Car, ExportCarInfoDto>()
                .ForMember(d => d.Make, mo => mo.MapFrom(s => s.Make))
                .ForMember(d => d.Model, mo => mo.MapFrom(s => s.Model))
                .ForMember(d => d.TravelledDistance, mo => mo.MapFrom(s => s.TravelledDistance));

            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Car, mo => mo.MapFrom(d => d))
                .ForMember(dest => dest.Parts, mo => mo.MapFrom(s => s.PartCars.Select(x => x.Part)));
        }
    }
}
