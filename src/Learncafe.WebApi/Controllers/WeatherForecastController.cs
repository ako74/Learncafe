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
    [Route("api/[controller]")]
    public abstract class LearncafeController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        public LearncafeController(IMediator mediator, ILoggerFactory loggerFactory)
        {
            if(loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }
            _logger = loggerFactory.CreateLogger(this.GetType());
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }

    public class WeatherForecastController : LearncafeController
    {
        public WeatherForecastController(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"User {User.Identity.Name} getting weather forecast.");
            var query = new WeatherQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
