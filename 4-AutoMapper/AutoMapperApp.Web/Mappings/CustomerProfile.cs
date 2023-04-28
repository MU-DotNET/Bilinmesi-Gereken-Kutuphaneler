using AutoMapper;
using AutoMapperApp.Web.DTOs;
using AutoMapperApp.Web.Models;

namespace AutoMapperApp.Web.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Isim, options => options.MapFrom(c => c.Name))
                .ForMember(dest => dest.Eposta, options => options.MapFrom(c => c.Email))
                .ForMember(dest => dest.Yas, options => options.MapFrom(c => c.Age))
                .ForMember(dest => dest.FullName2, options => options.MapFrom(c => c.FullName2()))
                .ForMember(dest => dest.CCNumber, options => options.MapFrom(c => c.CreditCard.Number))
                .ForMember(dest => dest.CCValidDate, options => options.MapFrom(c => c.CreditCard.ValidDate));
        }
    }
}
