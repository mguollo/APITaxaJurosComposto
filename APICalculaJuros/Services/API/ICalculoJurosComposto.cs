using System.Threading.Tasks;

namespace APICalculaJuros.Services.API
{
    public interface ICalculoJurosComposto
    {
         public Task<double> Calcular();
    }
}