using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learncafe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new string[] { "posprzątać", "pozmywać", "poruchać" };
            return Ok(result);
        }
    }
}