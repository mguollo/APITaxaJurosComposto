using APITaxaJuros.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace APITaxaJuros.Controllers
{    
    //[Produces("application/json")]
    [Route("[Controller]")]
    [ApiController] 
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna a taxa de juros para calculo de juros compostos
        /// </summary>
        /// <param name="taxaJuros">taxa de juros</param> 
        /// <returns>Json com valor na chave Taxa Juros</returns>        
        [HttpGet]
        public ActionResult GetTaxaJuros([FromServices] ITaxaJuros taxaJuros)
        {   
            var objeto = new { TaxaJuros = taxaJuros.PegarTaxaJuros() };
            var resultado = JsonSerializer.Serialize(objeto);  

            return Ok(resultado);
        }
        
    }
}