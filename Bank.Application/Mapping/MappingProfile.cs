using AutoMapper;
using Bank.Application.DTOs.ResponseDTOs;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;

namespace Bank.Application.Mapping;

public class MappingProfile : Profile
{


    public MappingProfile()
    {
        // Add your object-object mapping configurations here
        CreateMap<Account, AccountDto>().ReverseMap();


    }
}
