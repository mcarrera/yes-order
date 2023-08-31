using be_photosi_api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using be_photosi_api.Handlers.Dto;

namespace be_photosi_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<OrderController> logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost("AddOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError("Error in creating new order: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error in creating a new order : {ex}");
            }
        }
    }
}
