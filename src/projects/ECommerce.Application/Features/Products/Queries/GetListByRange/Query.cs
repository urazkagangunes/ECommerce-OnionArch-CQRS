using MediatR;
using Nest;

namespace ECommerce.Application.Features.Products.Queries.GetListByRange;

public class Query : MediatR.IRequest<List<ResponseDto>>
{
    public double? StockMin { get; set; }
    public double? StockMax { get; set; }
    public double? PriceMin { get; set; }
    public double? PriceMax { get; set; }

    public class QueryHandler : IRequestHandler<Query, List<ResponseDto>>
    {
        private readonly IElasticClient _elasticClient;

        public QueryHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<List<ResponseDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var searchResponse = await _elasticClient.SearchAsync<ResponseDto>(
                s => s.Index("products")
                    .Query(q => q
                        .Bool(b => b
                            .Filter(f => f
                                .Range(r => r
                                    .Field(p => p.Stock)
                                    .GreaterThanOrEquals(request.StockMin.HasValue ? request.StockMin : 0)
                                    .LessThanOrEquals(request.StockMax.HasValue ? request.StockMax : double.MaxValue)
                                )
                            )
                            .Filter(f => f
                                .Range(r => r
                                    .Field(p => p.Price)
                                    .GreaterThanOrEquals(request.PriceMin.HasValue ? request.PriceMin : 0)
                                    .LessThanOrEquals(request.PriceMax.HasValue ? request.PriceMax : double.MaxValue)
                                )
                            )
                        )
                    )
                );
            return searchResponse.Documents.ToList();
        }
    }
}