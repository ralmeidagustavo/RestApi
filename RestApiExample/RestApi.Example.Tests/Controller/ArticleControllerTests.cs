using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestApiExample.Api.Controllers;
using RestApiExample.Domain.Interfaces;

namespace RestApi.Example.Tests
{
    [TestClass]
    public class ArticleControllerTests
    {
        private readonly Mock<IArticleService> _articleService;

        public ArticleControllerTests()
        {
            _articleService = new Mock<IArticleService>();
        }

        [TestMethod]
        public async Task ArticleList_SuccessRequest_Should_Success()
        {
            //Arranje

            var controller = new ArticleController(_articleService.Object);

            // Ack

            await controller.Get("teste");

            // Assert

            _articleService.Verify(x => x.List("teste"), Times.Once);

        }

    }
}