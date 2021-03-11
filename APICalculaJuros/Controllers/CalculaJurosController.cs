using System;
using System.Threading.Tasks;
using APICalculaJuros.Services.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICalculaJuros.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetCalculaJuros([FromServices] IConsultaJuros consultaJuros)
        {
            try
            {
                var resultado = await consultaJuros.PegarTaxaJuros();
                return Ok(resultado);
            }  
            catch (Exception ex){
                Console.WriteLine("-----------Começa EXCEÇÃO------------");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.ToString());
                Console.WriteLine("-----------Termina EXCEÇÃO------------");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao calcular juros.");
            }
        }

        /*[HttpGet("variavelP")]
        public ActionResult<string> GetVariavelAmbienteP()
        {
            var valor = System.Environment.GetEnvironmentVariable("ENDERECO_TAXA_API", EnvironmentVariableTarget.Process);
            if (valor == null)
            {
                return "Variavel vazia";
            }
            else
                return valor;
        }*/
        
    }
}