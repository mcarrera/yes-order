using be_photosi_api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<ActionResult> AddOrder()
        {
            var connection = EnvironmentVariables.GetDatabaseConnection();

            return Ok(connection);
        }
    }
}
