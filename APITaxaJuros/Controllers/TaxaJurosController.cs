using APITaxaJuros.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace APITaxaJuros.Controllers
{
    [Route("[Controller]")]
    [ApiController] 
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetTaxaJuros([FromServices] ITaxaJuros taxaJuros)
        {   
            var resultado = new {TaxaJuros = taxaJuros.PegarTaxaJuros()};
            return Ok(resultado);
        }
        
    }
}