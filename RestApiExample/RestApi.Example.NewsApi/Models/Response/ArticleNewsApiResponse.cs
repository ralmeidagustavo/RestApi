using Newtonsoft.Json;

namespace RestApi.Example.NewsApi
{
    public class ArticleNewsApiResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("articles")]
        public List<ArticleDetailsNewsApiResponse> Articles { get; set; }
    }

    public class ArticleDetailsNewsApiResponse
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}