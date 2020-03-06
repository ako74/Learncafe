using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learncafe.WebApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Learncafe.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"User {User.Identity.Name} getting weather forecast");
            var query = new WeatherQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
