using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers;
using Microsoft.Extensions.Logging;
using Moq;
using AutoFixture;
using be_photosi_api.Data.Entities;
using be_photosi_api.Handlers.Command;

namespace be_photosi_tests.API.Handlers
{
    public class CreateOrderRequestHandlerTests
    {
        private readonly CreateOrderRequestHandler _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ILogger<CreateOrderRequestHandler>> _loggerMock;
        private readonly Fixture _fixture;

        public CreateOrderRequestHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _loggerMock = new Mock<ILogger<CreateOrderRequestHandler>>();
            _handler = new CreateOrderRequestHandler(_orderRepositoryMock.Object, _loggerMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsOrderId()
        {
            // Arrange
            var request = _fixture.Create<CreateOrderRequest>();


            var orderId = Guid.NewGuid();
            _orderRepositoryMock.Setup(repo => repo.AddOrder(It.IsAny<Order>()))
                .ReturnsAsync(orderId);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(orderId, result);
        }

        [Fact]
        public async Task Handle_Exception_ReturnsInternalServerError()
        {
            // Arrange
            var request =  _fixture.Create<CreateOrderRequest>();
            _orderRepositoryMock.Setup(repo => repo.AddOrder(It.IsAny<Order>()))
                .ThrowsAsync(new Exception("Test Exception"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}
