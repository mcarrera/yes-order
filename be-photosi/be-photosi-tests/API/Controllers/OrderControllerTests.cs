using AutoFixture;
using be_photosi_api.Controllers;
using be_photosi_api.Handlers.Command;
using be_photosi_api.Handlers.Dto;
using be_photosi_api.Handlers.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace be_photosi_tests.API.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<OrderController>> _loggerMock;
        private readonly OrderController _controller;
        private readonly Fixture _fixture;

        public OrderControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<OrderController>>();

            _controller = new OrderController(_mediatorMock.Object, _loggerMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task AddOrder_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var createOrderRequest = _fixture.Create<CreateOrderRequest>();
            var response = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.AddOrder(createOrderRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }


        [Fact]
        public async Task AddOrder_InvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var createOrderRequest = _fixture.Create<CreateOrderRequest>();
            createOrderRequest.Products = null;
            var response = Guid.NewGuid();

          
            // Act
            var result = await _controller.AddOrder(createOrderRequest);

            // Assert
            var badObjectResult = Assert.IsType<BadRequestObjectResult>(result);
           
        }


        [Fact]
        public async Task AddOrder_Exception_ReturnsInternalServerError()
        {
            // Arrange
            var createOrderRequest = _fixture.Create<CreateOrderRequest>();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await _controller.AddOrder(createOrderRequest);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetOrders_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var orders = _fixture.Create<List<OrderDto>>();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrders();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(orders, okResult.Value);
        }

        [Fact]
        public async Task GetOrders_Exception_ReturnsInternalServerError()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await _controller.GetOrders();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
      
        [Fact]
        public async Task DeleteOrder_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteOrderRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(true, okResult.Value);
        }

        [Fact]
        public async Task DeleteOrder_InvalidRequest_ReturnsNotFoundResult()
        {
            // Arrange
            var orderId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteOrderRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            var okResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(false, okResult.Value);
        }

        [Fact]
        public async Task DeleteOrder_Exception_ReturnsInternalServerError()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteOrderRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

    }

}
