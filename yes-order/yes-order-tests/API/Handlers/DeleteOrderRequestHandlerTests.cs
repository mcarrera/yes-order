using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories.Interfaces;
using yes_orders_api.Handlers;
using yes_orders_api.Handlers.Command;
using Microsoft.Extensions.Logging;
using Moq;

namespace yes_orders_tests.API.Handlers
{
    public  class DeleteOrderRequestHandlerTests
    {
        private readonly DeleteOrderRequestHandler _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ILogger<DeleteOrderRequestHandler>> _loggerMock;

        public DeleteOrderRequestHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _loggerMock = new Mock<ILogger<DeleteOrderRequestHandler>>();

            _handler = new DeleteOrderRequestHandler(_loggerMock.Object, _orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsTrue()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            _orderRepositoryMock.Setup(repo => repo.DeleteOrder(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var request = new DeleteOrderRequest
            {
                Id = orderId
            };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ReturnsFalse()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            _orderRepositoryMock.Setup(repo => repo.DeleteOrder(It.IsAny<Guid>()))
                .ReturnsAsync(false);

            var request = new DeleteOrderRequest
            {
                Id = orderId
            };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Handle_Exception_ReturnsInternalServerError()
        {
            // Arrange
            var request = new DeleteOrderRequest { Id = Guid.NewGuid() };
            _orderRepositoryMock.Setup(repo => repo.DeleteOrder(request.Id))
                .ThrowsAsync(new Exception("Test Exception"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}
