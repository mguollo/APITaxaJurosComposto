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
        /// <summary>
        /// Calculo dos juros compostos
        /// </summary>
        /// <remarks>
        /// Exemplo de request: 
        ///     http:localhost:7000/calculajuros?valorinicial=100&amp;meses=5
        ///         
        /// Onde:
        /// 
        ///     Valorinicial = valor da aplicação inicial, númerico.
        /// 
        ///     Meses = Valor de meses para o calculo dos juros, inteiro.
        /// 
        /// O valor da taxa de juros será consultado em serviço externo.
        /// 
        /// </remarks>
        /// <param name="consultaJuros"></param>
        /// <param name="ValorInicial"></param>
        /// <param name="Meses"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Repositório do projeto
        /// </summary>
        /// <returns>URL do repositório do Git</returns>
        [HttpGet("/showmethecode")]
        public ActionResult GetShowethecode()
        {
            return Ok("https://github.com/mguollo/APITaxaJurosComposto");
        }
    }
}