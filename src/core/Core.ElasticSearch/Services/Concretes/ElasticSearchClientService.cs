using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.ElasticSearch.Services.Abstrascts;
using Nest;

namespace Core.ElasticSearch.Services.Concretes;

public class ElasticSearchClientService : IElasticSearchClientService
{
    private readonly IElasticClient _elasticClient;

    public ElasticSearchClientService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }
    public async Task IndexDocumentAsync<T>(T document, string indexName) where T : class
    {
        var response = await _elasticClient.IndexAsync(document, idx => idx.Index(indexName));

        if (!response.IsValid)
        {
            throw new BusinessException(response.OriginalException.Message);
        }
    }

    public async Task<List<T>> SearchAsync<T>(string indexName) where T : class
    {
        var searchResponse = await _elasticClient.SearchAsync<T>(s => s.Index(indexName).Query(q => q.MatchAll()));

        return searchResponse.Documents.ToList();
    }

    public async Task<T> UpdateAsync<T>(string id, T updated) where T : class
    {
        var response = await _elasticClient.UpdateAsync<T>(id, u => u.Doc(updated));

        if (!response.IsValid)
        {
            throw new BusinessException(response.OriginalException.Message);
        }

        return updated;
    }
}