using Application.DTOs.Account;
using Application.DTOs.CoinApi;
using Application.DTOs.CoinGecko;
using Application.DTOs.Forum.Post;
using Application.DTOs.Forum.PostReply;
using Application.DTOs.NewsApi;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Domain.Models.CoinGecko;
using Domain.Models.News;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, BasePostDto>().ReverseMap();
        
        CreateMap<PostReply, PostReplyDto>().ReverseMap();
        
        CreateMap<AppUser, BaseUserDto>().ReverseMap();
        
        CreateMap<MarketExternalApi, MarketDto>().ReverseMap();
        
        CreateMap<ExchangeExternalApi, Exchange>().ReverseMap();
        CreateMap<ExchangeIconExternalApi, ExchangeIcon>().ReverseMap();

        CreateMap<ArticleExternalApi, Article>()
            .ForMember(d => d.SourceName, o => o.MapFrom(s => s.SourceExternalApi.Name))
            .ReverseMap();
    }
}