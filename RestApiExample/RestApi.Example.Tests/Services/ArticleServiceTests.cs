using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestApi.Example.NewsApi.Interfaces;
using RestApiExample.Domain.Services;

namespace RestApi.Example.Tests
{
    [TestClass]
    public class ArticleServiceTests
    {
        private readonly Mock<INewsApiClientInterface> _newsApiClientInterface;

        public ArticleServiceTests()
        {
            _newsApiClientInterface = new Mock<INewsApiClientInterface>();
        }

        [TestMethod]
        public async Task ArticleList_ValidTerm_SuccessRequest_Should_Success()
        {
            //Arranje

            var service = new ArticleService(_newsApiClientInterface.Object);

            // Ack

            await service.List("teste");

            // Assert

            _newsApiClientInterface.Verify(x => x.List("teste"), Times.Once);

        }

    }
}