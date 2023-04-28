using AutoMapper;
using AutoMapperApp.Web.DTOs;
using AutoMapperApp.Web.Models;

namespace AutoMapperApp.Web.Mappings
{
    public class EventDateProfile : Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDTO, EventDate>()
                .ForMember(e => e.Date, options => options.MapFrom(e => new DateTime(e.Year, e.Month, e.Day)));

            CreateMap<EventDate, EventDateDTO>()
                .ForMember(e => e.Year, options => options.MapFrom(e => e.Date.Year))
                .ForMember(e => e.Month, options => options.MapFrom(e => e.Date.Month))
                .ForMember(e => e.Day, options => options.MapFrom(e => e.Date.Day));
        }
    }
}
