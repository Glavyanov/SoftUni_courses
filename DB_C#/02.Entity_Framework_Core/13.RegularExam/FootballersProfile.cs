namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;
    using System.Linq;

    public class FootballersProfile : Profile
    {
        
        public FootballersProfile()
        {
            this.CreateMap<ImportTeamJsonDto, Team>()
                .ForMember(d => d.Trophies, mo => mo.MapFrom(s => int.Parse(s.Trophies)));
        }
    }
}
