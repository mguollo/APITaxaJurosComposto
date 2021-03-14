using System;
using System.Threading.Tasks;
using APICalculaJuros.Domains;
using APICalculaJuros.Services.API;
using APICalculaJuros.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICalculaJuros.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetCalculaJuros([FromServices] IConsultaJuros consultaJuros, [FromQuery] double ValorInicial, int Meses)
        {            
            try
            {   
                if (ValorInicial <= 0 || Meses <= 0 )
                    return BadRequest("Requisição com parâmetros inválidos. Esperado o seguinte formato: /calculajuros?valorinicial=100&meses=5");                
                                
                var calculoJurosComposto = new CalculoJurosComposto(consultaJuros, ValorInicial, Meses);

                var juros = await calculoJurosComposto.Calcular();

                return Ok(string.Format("{0:0,0.00}", juros));
            }  
            catch (Exception ex){
                Console.WriteLine("-----------Começa EXCEÇÃO------------");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.ToString());
                Console.WriteLine("-----------Termina EXCEÇÃO------------");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao calcular juros.");
            }
        }

        [HttpGet("/showmethecode")]
        public ActionResult GetShowethecode()
        {
            return Ok("https://github.com/mguollo/APITaxaJurosComposto");
        }
    }
}