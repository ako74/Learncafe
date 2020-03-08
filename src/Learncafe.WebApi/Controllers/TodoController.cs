using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learncafe.WebApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Learncafe.WebApi.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class TodoController : LearncafeController
    {
        public TodoController(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetTodosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}