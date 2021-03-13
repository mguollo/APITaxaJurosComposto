using APICalculaJuros.Services.API;
using System.Threading.Tasks;

namespace APICalculaJurosTest.Mock
{
    public class ConsultaJurosTest : IConsultaJuros
    {
        private double _valorJuro { get; }

        public ConsultaJurosTest(double valorJuro)
        {
            _valorJuro = valorJuro;
            
        }

        public async Task<double> PegarTaxaJuros()
        {            
            return _valorJuro;
        }    
    }
}