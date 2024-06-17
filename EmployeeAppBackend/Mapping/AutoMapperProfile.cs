using AutoMapper;
using EmployeeAppBackend.Controllers.Dto;
using EmployeeAppBackend.Domain;

namespace EmployeeAppBackend.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            // CreateMap<Domain.Employee, Dtos.EmployeeDto>().ReverseMap();
        }
    }
}
