using MediatR;
using Microsoft.AspNetCore.Mvc;
using be_photosi_api.Handlers.Query;
using be_photosi_api.Handlers.Command;
using be_photosi_api.Validators;
using System.Net;

namespace be_photosi_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataGeneratorController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<DataGeneratorController> _logger;
        public DataGeneratorController(IMediator mediator, ILogger<DataGeneratorController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost("GenerateOrders")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GenerateOrders([FromBody] GenerateOrderRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in generating orders: {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error in generating orders : {ex}");
            }
        }
    }
}
