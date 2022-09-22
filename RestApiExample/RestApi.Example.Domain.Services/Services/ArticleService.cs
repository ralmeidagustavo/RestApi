using RestApi.Example.NewsApi.Interfaces;
using RestApiExample.Domain.Dto.Articles;
using RestApiExample.Domain.Interfaces;

namespace RestApiExample.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly INewsApiClientInterface _newsApiClientInterface;
        
        public ArticleService(INewsApiClientInterface newsApiClientInterface)
        {
            _newsApiClientInterface = newsApiClientInterface;
        }

        public async Task<List<ArticleInfoDto>?> List(string? term)
        {
            var response = await _newsApiClientInterface.List(term);

            if (response != null) 
            {
                return response.Articles?.Select(c => new ArticleInfoDto()
                {
                    Author = c.Author,
                    Description = c.Description,
                    Title = c.Title
                }).ToList();
            }

            return null;
        }
    }
}