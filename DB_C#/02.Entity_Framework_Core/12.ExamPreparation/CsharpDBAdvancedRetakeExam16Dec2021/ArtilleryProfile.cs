namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    class ArtilleryProfile : Profile
    {
        public ArtilleryProfile()
        {
            this.CreateMap<ImportCountriesXmlDto, Country>();
            this.CreateMap<ImportManufacturerXmlDto, Manufacturer>();
            this.CreateMap<ImportShellXmlDto, Shell>();
            this.CreateMap<ImportCountryJsonDto, CountryGun>()
                .ForMember(d => d.CountryId, mo => mo.MapFrom(s => s.Id));
            this.CreateMap<ImportGunJsonDto, Gun>()
                .ForMember(d => d.CountriesGuns , mo => mo.MapFrom(s => s.Countries));
        }
    }
}