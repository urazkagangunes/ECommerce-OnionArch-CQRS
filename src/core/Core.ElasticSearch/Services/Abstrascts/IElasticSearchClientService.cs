namespace Core.ElasticSearch.Services.Abstrascts;

public interface IElasticSearchClientService
{
    Task IndexDocumentAsync<T>(T document, string indexName) where T : class;
    Task<List<T>> SearchAsync<T>(string indexName) where T : class;
    Task<T> UpdateAsync<T>(string id, T updated) where T : class;
}