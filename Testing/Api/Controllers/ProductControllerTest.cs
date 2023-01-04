using Moq;
using Xunit;
using Api.Controllers;
using Domain.Model;
using Domain.DTO;
using Infrastructure.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Testing.Builders;
namespace Testing;

public class ProductControllerTest
{

        private PaginationProduct productPaginations;
        private Product product;
        private Product productToUpdate;
        private Mock<IProductService> mockProductService;
        public ProductControllerTest()
        {
            productPaginations = ProductBuilder.BuildPaginationProduct();
            product = ProductBuilder.BuildProduct();
            productToUpdate = ProductBuilder.BuildProductToUpdate();
            mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public async Task Get_OnSuccess_RetuensStatusCode200()
        {
            //Arrange

            mockProductService
                .Setup(service => service.GetAllProducts(It.IsAny<int>(), It.IsAny<int>()))
                            .ReturnsAsync(productPaginations);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetProductsByPage(1, 1);

            //Assert

            result.StatusCode.Should().Be(200);
            mockProductService.Verify(service => service.GetAllProducts(It.IsAny<int>(), It.IsAny<int>()),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<PaginationProduct>();
        }
                [Fact]
        public async Task Get_NotFound_Returns404()
        {
            //Arrange

            mockProductService
                .Setup(service => service.GetAllProducts(1, 1))
                            .ReturnsAsync(productPaginations);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (NoContentResult)await sut.GetProductsByPage(2, 20);

            //Assert

            result.Should().BeOfType<NoContentResult>();
            var objectResult = (NoContentResult)result;

        }


        [Fact]
        public async Task GetsingleProduct_OnSuccess_RetuensStatusCode200()
        {
            //Arrange

            mockProductService
                .Setup(service => service.GetSingleProduct(It.IsAny<int>()))
                            .ReturnsAsync(product);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetSingleProduct(It.IsAny<int>());

            //Assert

            result.StatusCode.Should().Be(200);
            mockProductService.Verify(service => service.GetSingleProduct( It.IsAny<int>()),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<Product>();
        }
                [Fact]
        public async Task GetSingleProduct_NotFound_Returns404()
        {
            //Arrange

            mockProductService
                .Setup(service => service.GetSingleProduct(999))
                            .ReturnsAsync(product);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (NotFoundObjectResult)await sut.GetSingleProduct(It.IsAny<int>());

            //Assert

            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }


        [Fact]
        public async Task PostProduct_OnSuccess_RetuensStatusCode200()
        {
            //Arrange

            mockProductService
                .Setup(service => service.AddProduct(product))
                            .ReturnsAsync(product);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (OkObjectResult)await sut.AddProduct(product);

            //Assert

            result.StatusCode.Should().Be(200);
            mockProductService.Verify(service => service.AddProduct(product),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<Product>();
        }
                [Fact]
        public async Task PostProduct_Notadded_Returns404()
        {
            //Arrange

            mockProductService
                .Setup(service => service.AddProduct(product))
                            .ReturnsAsync((Product)null);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (NotFoundObjectResult)await sut.GetSingleProduct(It.IsAny<int>());

            //Assert

            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task PutProduct_OnSuccess_RetuensStatusCode200()
        {
            //Arrange

            mockProductService
                .Setup(service => service.UpdateProduct(productToUpdate))
                            .ReturnsAsync(product);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (OkObjectResult)await sut.UpdateProduct(productToUpdate);

            //Assert

            result.StatusCode.Should().Be(200);
            mockProductService.Verify(service => service.UpdateProduct(productToUpdate),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<Product>();
        }
        [Fact]
        public async Task PutProduct_Notadded_Returns404()
        {
            //Arrange

            mockProductService
                .Setup(service => service.UpdateProduct(productToUpdate))
                            .ReturnsAsync((Product)null);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (NotFoundObjectResult)await sut.UpdateProduct(productToUpdate);

            //Assert

            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteProduct_OnSuccess_RetuensStatusCode200()
        {
            //Arrange

            mockProductService
                .Setup(service => service.DeleteProduct(It.IsAny<int>()))
                            .ReturnsAsync(product);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (OkObjectResult)await sut.DeleteProduct(It.IsAny<int>());

            //Assert

            result.StatusCode.Should().Be(200);
            mockProductService.Verify(service => service.DeleteProduct(It.IsAny<int>()),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
        }

        [Fact]
        public async Task DeleteProduct_Notadded_Returns404()
        {
            //Arrange
            mockProductService
                .Setup(service => service.DeleteProduct(It.IsAny<int>()))
                            .ReturnsAsync((Product)null);

            var sut = new ProductController(mockProductService.Object);

            //Act
            var result = (NotFoundObjectResult)await sut.DeleteProduct(It.IsAny<int>());

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
}
