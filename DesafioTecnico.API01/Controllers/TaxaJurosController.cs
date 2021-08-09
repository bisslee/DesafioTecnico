using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.API01.Controllers
{
    [ApiController]
    [Route("api/taxa-juros")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ILogger<TaxaJurosController> _logger;
        public TaxaJurosController(ILogger<TaxaJurosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("{ \"juro\": 0.01}");
        }
    }
}
