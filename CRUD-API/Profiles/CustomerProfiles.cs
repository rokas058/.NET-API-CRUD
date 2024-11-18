using AutoMapper;
using CRUD_API.Models.Dto;
using CRUD_API.Models.Entities;

namespace CRUD_API.Profiles
{
    public class CustomerProfiles : Profile
    {
        public CustomerProfiles() 
        {
            CreateMap<Customer, CustomerFormDto>();
            CreateMap<CustomerFormDto, Customer>();
            CreateMap<Customer, CustomerReturnDto>();
            CreateMap<CustomerReturnDto, Customer>();
        }
    }
}
