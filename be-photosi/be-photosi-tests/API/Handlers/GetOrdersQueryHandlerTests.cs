using be_photosi_api.Data.Entities;
using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers;
using be_photosi_api.Handlers.Dto;
using be_photosi_api.Handlers.Query;
using Microsoft.Extensions.Logging;
using Moq;
using AutoFixture;

namespace be_photosi_tests.API.Handlers
{
    public class GetOrdersQueryHandlerTests
    {
        private readonly GetOrdersQueryHandler _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ILogger<GetOrdersQueryHandler>> _loggerMock;
        private readonly Fixture _fixture;

        public GetOrdersQueryHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _loggerMock = new Mock<ILogger<GetOrdersQueryHandler>>();
            _handler = new GetOrdersQueryHandler(_loggerMock.Object, _orderRepositoryMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsListOfOrderDto()
        {
            // Arrange
            var count = _fixture.Create<byte>();
            var orders = new List<Order>();

            for (var i = 0; i < count; i++)
            {
                orders.Add(new Order
                {
                    Id = Guid.NewGuid(),
                    User = new User
                    {
                        Id = Guid.NewGuid(),
                        Username = _fixture.Create<string>()
                    },
                    DeliveryAddress = _fixture.Create<Address>(),
                    OrderProducts = new List<OrderProduct>(),
                    IsDeleted = _fixture.Create<bool>(),
                });
            }

            var expectedResponse = orders.Where(o => !o.IsDeleted).Select(x => new OrderDto
            {
                Id = x.Id,
                Username = x.User.Username
            }).ToList();

            _orderRepositoryMock.Setup(repo => repo.GetOrders())
                .ReturnsAsync(orders.Where(o => !o.IsDeleted).ToList());

            var request = new GetOrdersQuery();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResponse.Count, result.Count);

        }

        [Fact]
        public async Task Handle_Exception_ReturnsInternalServerError()
        {
            // Arrange
            _orderRepositoryMock.Setup(repo => repo.GetOrders())
                .ThrowsAsync(new Exception("Test Exception"));

            var request = new GetOrdersQuery();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
        }


    }
}
