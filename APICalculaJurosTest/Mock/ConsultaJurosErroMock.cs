using System.Threading.Tasks;
using APICalculaJuros.Services.API;

namespace APICalculaJurosTest.Mock
{
    public class ConsultaJurosErroMock : IConsultaJuros
    {
        public Task<double> PegarTaxaJuros()
        {
            throw new System.NotImplementedException("Erro método não implementado - Testes de unidade");
        }
    }
}