using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;
using Application.DTOs.CompanyDtos;
using Application.DTOs.UserDtos;
using AutoMapper;
using Domain.Entities;

namespace BUGgalteriyaAPI.Application.Common.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Company, AddCompanyDto>();
        CreateMap<Company, CompanyDto>().ReverseMap();

        CreateMap<Bugalter, AddBugalterDto>();
        CreateMap<Bugalter, BugalterDto>().ReverseMap();

        CreateMap<AddUserDto, User>();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
