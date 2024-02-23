using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using yes_orders_api.Handlers.Query;
using yes_orders_api.Handlers.Command;
using yes_orders_api.Validators;

namespace yes_orders_api.Controllers
{
    /// <summary>
    /// Controller to manage orders
    /// </summary>
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

        /// <summary>
        /// Add an order
        /// </summary>
        /// <param name="request">A request to create an order</param>
        /// <returns></returns>
        [HttpPost("AddOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var validation = await new CreateOrderRequestValidator().ValidateAsync(request);
                if (!validation.IsValid)
                    return BadRequest(validation.Errors);

                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in creating new order: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error in creating a new order : {ex}");
            }
        }

        /// <summary>
        /// Get all the non deleted orders for all the users
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Mark an order as deleted (soft delete)
        /// </summary>
        /// <param name="orderId">The order to mark for deletion</param>
        /// <returns></returns>

        [HttpDelete("DeleteOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteOrder([FromQuery] Guid orderId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteOrderRequest
                {
                    Id = orderId
                });
                if (response)
                {
                    return Ok(response);
                }

                return NotFound(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in deleting order: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error in deleting order : {ex}");
            }
        }
    }
}
