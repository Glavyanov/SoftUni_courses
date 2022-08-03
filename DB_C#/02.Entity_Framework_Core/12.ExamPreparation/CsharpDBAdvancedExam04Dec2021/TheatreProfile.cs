namespace Theatre
{
    using AutoMapper;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ImportDto;

    class TheatreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public TheatreProfile()
        {
            this.CreateMap<ImportPlayXmlDto, Play>();
            this.CreateMap<ImportCastXmlDto, Cast>();
            this.CreateMap<ImportTicketJsonDto, Ticket>();
            this.CreateMap<ImportTheatreJsonDto, Theatre>();
        }
    }
}
