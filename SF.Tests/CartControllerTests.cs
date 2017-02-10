using SF.WebServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using SF.WebServer.Api;
using Xunit;

namespace SF.Tests
{
    public class CartControllerTests

    {
        public string RequestID { get; set; }



        public CartControllerTests()
        {
            RequestID = Guid.NewGuid().ToString();
        }

        [Fact]
        public void ListContentsReturnsCart()
        {
            IProductRepository ProductRepo = new MemProductRepository();
            ICartRepository CartRepo = new MemCartRepository();
            // Arrange
            var controller = new CartController(ProductRepo, CartRepo);

            // Act
            var result = controller.ListContents() as OkNegotiatedContentResult<List<Product>>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Content.Count);
        }


        [Fact]
        public void AddItemToCart_CreatesCartAndAddsItems()
        {
            IProductRepository ProductRepo = new MemProductRepository();
            ICartRepository CartRepo = new MemCartRepository();

            // Arrange 
            var controller = new CartController(ProductRepo, CartRepo)
            {
                Request = new HttpRequestMessage()

            };
            controller.Request.Properties.Add("cid", RequestID);

            // Act
            var result = controller.AddItemToCart(1) as OkResult;

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.NotNull(CartRepo.GetById(RequestID));
            Assert.True(CartRepo.GetById(RequestID).Contents.Exists(p => p.ID == 1));

        }

        [Fact]
        public void RemoveItemFromCart_RemovesRequestedItemFromCart()
        {
            IProductRepository ProductRepo = new MemProductRepository();
            ICartRepository CartRepo = new MemCartRepository();

            // Arrange
            var controller = new CartController(ProductRepo, CartRepo)
            {
                Request = new HttpRequestMessage()
            };

            controller.Request.Properties.Add("cid", RequestID);
            controller.AddItemToCart(1);


            // Act
            var result = controller.RemoveItemFromCart(1) as OkResult;

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.NotNull(CartRepo.GetById(RequestID));
            Assert.False(CartRepo.GetById(RequestID).Contents.Exists(p => p.ID == 1));
        }


        [Fact]
        public void RemoveItemFromCart_RemoveItemFromCartWhenItDoesntExist()
        {
            IProductRepository ProductRepo = new MemProductRepository();
            ICartRepository CartRepo = new MemCartRepository();

            // Arrange
            var controller = new CartController(ProductRepo, CartRepo)
            {
                Request = new HttpRequestMessage()
            };

            controller.Request.Properties.Add("cid", RequestID);

            // Act
            var result = controller.RemoveItemFromCart(1) as OkResult;

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.NotNull(CartRepo.GetById(RequestID));
            Assert.Empty(CartRepo.GetById(RequestID).Contents);
        }

        [Fact]
        public void ClearCart_ClearsAllItemsFromCart()
        {
            IProductRepository ProductRepo = new MemProductRepository();
            ICartRepository CartRepo = new MemCartRepository();

            // Arrange
            var controller = new CartController(ProductRepo, CartRepo)
            {
                Request = new HttpRequestMessage()
            };

            controller.Request.Properties.Add("cid", RequestID);

            controller.AddItemToCart(1);
            controller.AddItemToCart(2);
            controller.AddItemToCart(3);

            // Act
            var result = controller.ClearCart() as OkResult;

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.NotNull(CartRepo.GetById(RequestID));
            Assert.Empty(CartRepo.GetById(RequestID).Contents);
        }

    }
}
