using System;
using System.Threading.Tasks;
using APICalculaJuros.Domains;
using APICalculaJuros.Services.API;

namespace APICalculaJuros.Services.Impl
{
    public class CalculoJurosComposto : ICalculoJurosComposto
    {
        private double ValorInicial { get; }
        private int Meses { get; }
        private IConsultaJuros ConsultaJuros { get; } 
        
        public CalculoJurosComposto(IConsultaJuros consultajuros, double valorinicial, int meses)        
        {
            ConsultaJuros = consultajuros;
            ValorInicial = valorinicial;
            Meses = meses;
        }

        public async Task<double> Calcular()
        {
            var juroComposto = await RetornarTaxaJuros();
            return CalcularJuroComposto(juroComposto);
        }

        public double CalcularJuroComposto(JurosCompostos jurosCompostos)
        {
            var juros = jurosCompostos.ValorInicial * Math.Pow((1 + jurosCompostos.TaxaJuros), jurosCompostos.Meses);
            juros = Math.Truncate(juros*100)/100;

            return juros;
        }
        public async Task<JurosCompostos> RetornarTaxaJuros()
        {            
            var taxajuros = await ConsultaJuros.PegarTaxaJuros();
            var juroComposto = new JurosCompostos(ValorInicial, Meses, taxajuros);            
            
            return juroComposto;            
        }
    }
}