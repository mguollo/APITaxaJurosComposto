using System;
using Xunit;
using APICalculaJuros.Controllers;
using APICalculaJurosTest.Mock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using APICalculaJuros.Services.API;
using APICalculaJuros.Services.Impl;
using APICalculaJuros.Domains;

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
            var consultaJuros = new ConsultaJurosMock(0.01);
            double valorCorreto = 105.10;

            var actionResult = await Controller.GetCalculaJuros(consultaJuros, 100, 5);
            
            var viewResult = Assert.IsType<OkObjectResult>(actionResult);            
            Assert.Equal<double>(valorCorreto, Convert.ToDouble(viewResult.Value));
        }

        [Fact]
        public async Task Get_CalculaJurosValorInicialZerado_RetornaBadRequest()
        {
            var consultaJuros = new ConsultaJurosMock(0.01);
            var actionResult = await Controller.GetCalculaJuros(consultaJuros, 0, 5);

            Assert.IsType<BadRequestObjectResult>(actionResult);            
        }

        [Fact]
        public async Task Get_CalculaJurosMesesZerado_RetornaBadRequest()
        {
            var consultaJuros = new ConsultaJurosMock(0.01);
            var actionResult = await Controller.GetCalculaJuros(consultaJuros, 100, 0);

            Assert.IsType<BadRequestObjectResult>(actionResult);        
        }

        [Fact]
        public async Task Get_CalculaJuros_RetornaNaoOKNaoBadRequest()
        {
            var consultaJuros = new ConsultaJurosErroMock();
            var actionResult = await Controller.GetCalculaJuros(consultaJuros, 100, 5);
                        
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
            Assert.IsNotType<OkObjectResult>(actionResult);            
        }

        [Fact]
        public void Get_ShowMeTheCode_RetornaURLGit()
        {
            var actionResult = Controller.GetShowethecode();

            var viewResult = Assert.IsType<OkObjectResult>(actionResult);            
            Assert.Equal("https://github.com/mguollo/APITaxaJurosComposto", viewResult.Value.ToString());
        }
              
        [Fact]
        public async Task Get_Calcular_RetornaDouble()
        {
            var consultaJuros = new ConsultaJurosMock(0.01);
            ICalculoJurosComposto calculoJuro = new CalculoJurosComposto(consultaJuros, 200, 10);

            var valor = await calculoJuro.Calcular();

            Assert.Equal<double>(220.92, valor);
        }

        [Fact]
        public async Task Get_CalcularJuro_RetornaDouble()
        {
            double taxa = 0.53;
            double valorInicial = 200.7;
            int meses = 10;
            JurosCompostos jurosCompostos = new JurosCompostos(valorInicial, meses, taxa);
            var consultaJuros = new ConsultaJurosMock(taxa);
            CalculoJurosComposto calculoJuro = new CalculoJurosComposto(consultaJuros, valorInicial, meses);

            var valor = calculoJuro.CalcularJuroComposto(jurosCompostos);

            Assert.Equal<double>(14107.87, valor);
        }

        [Fact]
        public async Task Get_RetornarTaxaJuro_RetornaDouble()
        {
            double taxa = 0.53;
            double valorInicial = 200.7;
            int meses = 10;
            var consultaJuros = new ConsultaJurosMock(taxa);
            CalculoJurosComposto calculoJuro = new CalculoJurosComposto(consultaJuros, valorInicial, meses);

            JurosCompostos jurosCompostos = await calculoJuro.RetornarTaxaJuros();

            Assert.Equal<double>(valorInicial, jurosCompostos.ValorInicial);
            Assert.Equal<int>(meses, jurosCompostos.Meses);
            Assert.Equal<double>(taxa, jurosCompostos.TaxaJuros);
        }

    }
}
