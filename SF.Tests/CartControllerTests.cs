using SF.WebServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using SF.WebServer.Api;
using Xunit;

namespace SF.Tests
{
    public class CartControllerTests
    {
        [Fact]
        public void ListContentsReturnsCart()
        {
            // Arrange
            var controller = new CartController();

            // Act
            var result = controller.ListContents() as OkNegotiatedContentResult<List<Product>>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Content.Count);
        }
    }
}
