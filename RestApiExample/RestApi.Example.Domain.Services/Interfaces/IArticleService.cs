
using RestApiExample.Domain.Dto.Articles;

namespace RestApiExample.Domain.Interfaces
{
    public interface IArticleService 
    {
        Task<List<ArticleInfoDto?>> List(string? term);
    };
}