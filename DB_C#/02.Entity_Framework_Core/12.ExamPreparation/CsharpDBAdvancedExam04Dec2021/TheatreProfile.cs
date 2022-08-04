namespace Theatre
{
    using AutoMapper;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ImportDto;

    class TheatreProfile : Profile
    {
        
        public TheatreProfile()
        {
            this.CreateMap<ImportPlayXmlDto, Play>();
            this.CreateMap<ImportCastXmlDto, Cast>();
            this.CreateMap<ImportTicketJsonDto, Ticket>();
            this.CreateMap<ImportTheatreJsonDto, Theatre>();
            this.CreateMap<Ticket, ExportTicketJsonDto>();
            this.CreateMap<Theatre, ExportTheaterJsonDto>()
                .ForMember(d => d.TotalIncome,
                mo => mo.MapFrom(s => s.Tickets.Sum(t => t.RowNumber >= 1 && t.RowNumber <= 5 ? t.Price : 0)))
                .ForMember(d => d.Tickets, mo => mo.MapFrom(s => s.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)));
        }
    }
}
