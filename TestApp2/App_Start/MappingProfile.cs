using AutoMapper;
using TestApp2.Dtos;
using TestApp2.Models;

namespace TestApp2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<CustomerDtos, Customer>();
        }
    }
}