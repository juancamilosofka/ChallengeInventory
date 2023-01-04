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

public class BuyControllerTest
{

        private List<Buy> buys;
        private Buy buy;
        private Buy buyToUpdate;
        private Mock<IBuyService> mockBuyService;
        public BuyControllerTest()
        {
            buys = BuyBuilder.BuildBuys();
            buy = BuyBuilder.BuildBuy();
            buyToUpdate = BuyBuilder.BuildBuyToUpdate();
            mockBuyService = new Mock<IBuyService>();
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange

            mockBuyService
                .Setup(service => service.GetBuyByBuyerId(It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(buys);

            var sut = new BuyController(mockBuyService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetBuyByBuyerId(It.IsAny<string>(), It.IsAny<string>());

            //Assert

            result.StatusCode.Should().Be(200);
            mockBuyService.Verify(service => service.GetBuyByBuyerId(It.IsAny<string>(), It.IsAny<string>()),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<PaginationProduct>();
        }
        [Fact]
        public async Task Get_NotFound_Returns404()
        {
          //Arrange

            mockBuyService
                .Setup(service => service.GetBuyByBuyerId(It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync((List<Buy>)null);

            var sut = new BuyController(mockBuyService.Object);

            //Act
            var result = (NoContentResult)await sut.GetBuyByBuyerId(It.IsAny<string>(), It.IsAny<string>());

            //Assert

            result.Should().BeOfType<NoContentResult>();
            var objectResult = (NoContentResult)result;

        }


      

        [Fact]
        public async Task PostBuy_OnSuccess_RetuensStatusCode200()
        {
            //Arrange

            mockBuyService
                .Setup(service => service.AddBuy(buy))
                            .ReturnsAsync(buy);

            var sut = new BuyController(mockBuyService.Object);

            //Act
            var result = (OkObjectResult)await sut.AddBuy(buy);

            //Assert

            result.StatusCode.Should().Be(200);
            mockBuyService.Verify(service => service.AddBuy(buy),
            Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<Product>();
        }
                [Fact]
        public async Task PostBuy_Notadded_Returns404()
        {
            //Arrange

            mockBuyService
                .Setup(service => service.AddBuy(buy))
                            .ReturnsAsync((Buy)null);

            var sut = new BuyController(mockBuyService.Object);

            //Act
            var result = (NotFoundObjectResult)await sut.AddBuy(buy);

            //Assert

            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

}
