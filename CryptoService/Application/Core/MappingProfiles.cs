using Application.DTOs.CoinApi;
using Application.DTOs.CoinGecko;
using Application.DTOs.NewsApi;
using AutoMapper;
using Domain.Models;
using Domain.Models.CoinGecko;
using Domain.Models.News;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MarketExternalApi, MarketDto>().ReverseMap();
        
        CreateMap<ExchangeExternalApi, Exchange>().ReverseMap();
        CreateMap<ExchangeIconExternalApi, ExchangeIcon>().ReverseMap();

        CreateMap<ArticleExternalApi, Article>()
            .ForMember(d => d.SourceName, o => o.MapFrom(s => s.SourceExternalApi.Name))
            .ReverseMap();
    }
}