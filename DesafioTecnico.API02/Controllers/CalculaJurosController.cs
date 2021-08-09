using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.API02.Controllers
{
    [ApiController]
    [Route("api/calcula-juros")]
    public class CalculaJurosController : ControllerBase
    {

        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ILogger<CalculaJurosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<decimal> Get()
        {
            var result = 0.01m;
            return Ok(result);
        }
    }
}
