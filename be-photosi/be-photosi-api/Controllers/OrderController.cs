using be_photosi_api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using be_photosi_api.Handlers;
using be_photosi_api.Handlers.Dto;
using be_photosi_api.Handlers.Query;

namespace be_photosi_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in creating new order: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error in creating a new order : {ex}");
            }
        }

        [HttpGet("GetOrders")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                var response = await _mediator.Send(new GetOrdersQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in getting orders: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error in getting orders : {ex}");
            }
        }
    }
}
