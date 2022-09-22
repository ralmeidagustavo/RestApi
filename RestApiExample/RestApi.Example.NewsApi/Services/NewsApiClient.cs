using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestApi.Example.NewsApi.Interfaces;
using RestApiExample.Domain.Services;

namespace RestApi.Example.NewsApi.Services
{
    public class NewsApiClient : INewsApiClientInterface
    {
        private readonly ArticleOptions _articleOptions;
        private readonly ILogger<NewsApiClient> _logger;

        public NewsApiClient(IOptions<ArticleOptions> articleOptions, ILogger<NewsApiClient> logger)
        {
            _articleOptions = articleOptions.Value;

            _logger = logger;
        }

        public async Task<ArticleNewsApiResponse?> List(string? term = "developer")
        {
            try
            {
                var client = new HttpClient();
                var url = _articleOptions.BasePath + $"?apiKey={_articleOptions.ApiKey}";

                url += $"&q={term}";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ArticleNewsApiResponse>(content);
                }

                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Falha ao obter os dados de artigos");
                return null;
            }
        }
    }
}