using APITaxaJuros.Controllers;
using APITaxaJuros.Services;
using APITaxaJurosTest.Mock;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace APITaxaJurosTest
{
    public class APITaxaJurosTest
    {
        public TaxaJurosController Controller { get; }

        public APITaxaJurosTest()
        {
            Controller = new TaxaJurosController();            
        }

        public class TaxaJurosTest
        {
            public double TaxaJuros { get; set; }
        }

        [Fact]
        public void Get_TaxaJuros_RetornaDouble()
        {
            double taxa = 5;
            ITaxaJuros taxaJuros = new TaxaJurosMock(taxa);
            var actionResult = Controller.GetTaxaJuros(taxaJuros);

            var viewResult = Assert.IsType<OkObjectResult>(actionResult);
             
            TaxaJurosTest taxajuros = JsonSerializer.Deserialize<TaxaJurosTest>(viewResult.Value.ToString());
            Assert.Equal<double>(taxa, taxajuros.TaxaJuros);

        }
    }
}
