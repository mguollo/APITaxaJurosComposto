using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using APICalculaJuros.Domains;
using APICalculaJuros.Services.API;

namespace APICalculaJuros.Services.Impl
{    
    public class ConsultaJuros : IConsultaJuros
    {        
        private string GetURITaxaJuros()
        {
            var valor = System.Environment.GetEnvironmentVariable("ENDERECO_TAXA_API", EnvironmentVariableTarget.Process);
            if (valor == null)
            {
                throw new Exception("Variável de ambiente ENDERECO_TAXA_API não configurada.");                
            }
            else
                return valor;
        }
        public async Task<float> PegarTaxaJuros()
        {
            try
            {
                var httpClient = new HttpClient();           
                TaxaJuros taxajuros = await httpClient.GetFromJsonAsync<TaxaJuros>(GetURITaxaJuros());
                //TaxaJuros taxajuros = await httpClient.GetFromJsonAsync<TaxaJuros>("http://localhost:7000/TaxaJuros");

                return taxajuros.taxaJuros;
            }
            catch
            {
                throw;
            }
        }
    }
}