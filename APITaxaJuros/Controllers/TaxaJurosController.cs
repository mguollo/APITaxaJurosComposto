using APITaxaJuros.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace APITaxaJuros.Controllers
{    
    [Route("[Controller]")]
    [ApiController] 
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetTaxaJuros([FromServices] ITaxaJuros taxaJuros)
        {   
            var objeto = new { TaxaJuros = taxaJuros.PegarTaxaJuros() };
            var resultado = JsonSerializer.Serialize(objeto);  

            return Ok(objeto);
        }
        
    }
}