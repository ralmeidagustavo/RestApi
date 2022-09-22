using Microsoft.AspNetCore.Mvc;
using RestApiExample.Domain.Dto.Articles;
using RestApiExample.Domain.Interfaces;
using System.Net;

namespace RestApiExample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// Retorna a lista de artigos
        /// </summary>
        /// <param name="term">Termo a ser pesquisado</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ArticleInfoDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get([FromQuery] string? term = "developer")
        {
            var response = await _articleService.List(term);

            return Ok(response);

        }
    };
}