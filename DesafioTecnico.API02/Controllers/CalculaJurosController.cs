using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [HttpGet("{valorInicial}/{intervalo}")]
        public ActionResult<decimal> Get(decimal valorInicial, int intervalo)
        {

            var res = Getter();
            //var taxaJuro = 0.01M;

            var taxaJuro = JsonConvert.DeserializeObject<TaxaJuro>(res);

            var result = CalculaValor(valorInicial, intervalo, taxaJuro.Juro);
            return Ok(result);
        }

        private decimal CalculaValor(decimal valorInicial, int intervalo, decimal taxaJuro)
        {
            return decimal.Round(valorInicial * (decimal)Math.Pow(1.0 + (double)taxaJuro, intervalo), 2);
        }

        public static string Getter()
        {
            using (var client = new HttpClient())
            {
                var uri = @"https://localhost:44323/api/taxa-juros";
                var responseTask = client.GetAsync(uri);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return "Erro no servidor. Contate o Administrador.";
                }
            }
        }
    }

    public class TaxaJuro
    {
        public decimal Juro { get; set; }
    }
}
