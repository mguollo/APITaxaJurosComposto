using System.Threading.Tasks;

namespace APICalculaJuros.Services.API
{
    public interface IConsultaJuros
    {
         public Task<double> PegarTaxaJuros();
    }
}