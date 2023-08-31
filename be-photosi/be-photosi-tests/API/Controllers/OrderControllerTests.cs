using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Azure;
using be_photosi_api.Common;
using be_photosi_api.Controllers;
using be_photosi_api.Handlers;
using be_photosi_api.Handlers.Dto;
using be_photosi_api.Handlers.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

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
    }

}
