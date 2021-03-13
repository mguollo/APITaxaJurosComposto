using System;
using Xunit;
using APICalculaJuros.Controllers;
using APICalculaJurosTest.Mock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APICalculaJurosTest
{
    public class CalculaJurosTest
    {        
        private CalculaJurosController Controller { get; }

        public CalculaJurosTest()
        {
            Controller = new CalculaJurosController();
        }

        [Fact]
        public async Task Get_CalculaJuros_RetornaJuros()
        {                        
            var consultaJuros = new ConsultaJurosTest(0.01);
            double valorCorreto = 105.10;

            var actionResult = await Controller.GetCalculaJuros(consultaJuros, 100, 5);
            
            var viewResult = Assert.IsType<OkObjectResult>(actionResult);            
            Assert.Equal<double>(valorCorreto, (double) viewResult.Value);
        }

        [Fact]
        public async Task Get_CalculaJurosValorInicialZerado_RetornaBadRequest()
        {
            var consultaJuros = new ConsultaJurosTest(0.01);
            var actionResult = await Controller.GetCalculaJuros(consultaJuros, 0, 5);

            Assert.IsType<BadRequestObjectResult>(actionResult);            
        }

        [Fact]
        public async Task Get_CalculaJurosMesesZerado_RetornaBadRequest()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task Get_CalculaJuros_RetornaInternalServerError()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task Get_ShowMeTheCode_RetornaURLGit()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task Get_VariavelAmbienteURL_RetornaString()
        {
            Assert.True(false);
        }

        [Fact]
        public async Task Get_TaxaJurosAPI_RetornaDouble()
        {
            Assert.True(false);
        }

    }
}
