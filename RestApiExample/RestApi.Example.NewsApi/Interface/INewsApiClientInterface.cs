namespace RestApi.Example.NewsApi.Interfaces
{
    public interface INewsApiClientInterface
    {
        Task<ArticleNewsApiResponse?> List(string? term = "developer");
    }
}