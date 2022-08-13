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

            //Parts
            this.CreateMap<ImportPartDto, Part>();

            //Customers
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dest => dest.BirthDate, mo => mo.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            //Sales
            this.CreateMap<ImportSalesDto, Sale>();
        }
    }
}
