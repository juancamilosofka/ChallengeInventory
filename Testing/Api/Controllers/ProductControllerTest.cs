using Moq;
using Xunit;
using Api.Controllers;
using Domain.Model;
using Domain.DTO;
using Infrastructure.Services;

namespace Testing;

public class ProductControllerTest
{

        private List<PaginationProduct> productPaginations;
        private Product product;
        private Mock<IProductService> mockProductService;
        public ProductControllerTest()
        {
            users = UserBuilder.BuildUsers();
            user = UserBuilder.BuildSingleUser();
            mockUserService = new Mock<IUsersService>();
        }

                [Fact]
        public async Task Post_OnSuccess_RetuensStatusCode200()
        {
            //Arrange
            
            mockUserService
                .Setup(service => service.AddUser(user))
                            .ReturnsAsync(users);

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = (OkObjectResult)await sut.AddUser(user);

            //Assert
            result.StatusCode.Should().Be(200);


}
}