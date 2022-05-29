using Application.Contracts.ExternalAPI;
using Application.Core;
using Application.DTOs.CoinApi;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Features.CoinApi.Query;

public class GetAllExchangesIcons
{
    public class Query : IRequest<Result<List<ExchangeIcon>>>
    {
        public int IconSize { get; set; }
    }

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(x => x.IconSize).GreaterThan(0).NotNull();
        }
    }

    public class Handler : IRequestHandler<Query, Result<List<ExchangeIcon>>>
    {
        private readonly ICoinApiClient _coinApiClient;
        private readonly IMapper _mapper;

        public Handler(ICoinApiClient coinApiClient, IMapper mapper)
        {
            _coinApiClient = coinApiClient;
            _mapper = mapper;
        }

        public async Task<Result<List<ExchangeIcon>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var validationResult = await new Validator().ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return Result<List<ExchangeIcon>>.Failure(validationResult);

            var exchangesIcons = await _coinApiClient.GetAllExchangesIcons(request.IconSize.ToString());

            var exchangesIconsToReturn = _mapper.Map<List<ExchangeIconExternalApi>, List<ExchangeIcon>>(exchangesIcons);

            return exchangesIconsToReturn.Count > 0
                ? Result<List<ExchangeIcon>>.Success(exchangesIconsToReturn)
                : Result<List<ExchangeIcon>>.Failure("Problem with fetching Exchanges Icons");
        }
    }
}