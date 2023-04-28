using AutoMapper;
using AutoMapperApp.Web.DTOs;
using AutoMapperApp.Web.Models;

namespace AutoMapperApp.Web.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
