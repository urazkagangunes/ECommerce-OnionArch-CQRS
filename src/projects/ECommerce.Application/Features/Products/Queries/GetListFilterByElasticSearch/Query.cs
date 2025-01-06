using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Nest;

namespace ECommerce.Application.Features.Products.Queries.GetListFilterByElasticSearch;

public class Query : MediatR.IRequest<List<ResponseDto>>
{
    public string Text { get; set; }

    public class QueryHandler : IRequestHandler<Query, List<ResponseDto>>
    {
        private readonly IElasticClient _elasticClient;

        public QueryHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<List<ResponseDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var text = request.Text;
            var searchResponse = await _elasticClient.SearchAsync<ResponseDto>(
                s => s.Index("products")
                    .Query(b => b
                        .Bool(b => b
                            .Should(
                                sh => sh.Match(m => m.Field(p => p.Name).Query(text).Fuzziness(Fuzziness.Auto)),
                                sh => sh.Match(m => m.Field(p => p.Description).Query(text).Fuzziness(Fuzziness.Auto))
                            )
                        )
                    )
                );
            if (!searchResponse.IsValid)
            {
                throw new BusinessException (searchResponse.ServerError.Error.Reason);
            }

            return searchResponse.Documents.ToList();
        }
    }
}