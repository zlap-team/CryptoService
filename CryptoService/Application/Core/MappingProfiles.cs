using Application.DTOs.CoinApi;
using AutoMapper;
using Domain.Models;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ExchangeExternalApi, Exchange>().ReverseMap();
        CreateMap<ExchangeIconExternalApi, ExchangeIcon>().ReverseMap();
    }
}