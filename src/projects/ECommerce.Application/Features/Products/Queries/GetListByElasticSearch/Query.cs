using Core.ElasticSearch.Services.Abstrascts;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetListByElasticSearch;

public class Query : IRequest<List<ResponseDto>>
{
    public class QueryHandler : IRequestHandler<Query, List<ResponseDto>>
    {
        private readonly IElasticSearchClientService _elasticSearchClientService;

        public QueryHandler(IElasticSearchClientService elasticSearchClientService)
        {
            _elasticSearchClientService = elasticSearchClientService;
        }

        public Task<List<ResponseDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var response = _elasticSearchClientService.SearchAsync<ResponseDto>("products");

            return response;
        }
    }
}