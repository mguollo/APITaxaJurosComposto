using APITaxaJuros.Services;

namespace APITaxaJurosTest.Mock
{
    public class TaxaJurosMock : ITaxaJuros
    {
        public double TaxaJuros { get; }

        public TaxaJurosMock(double taxajuros)
        {
            TaxaJuros = taxajuros;
        }
        public double PegarTaxaJuros()
        {
            return TaxaJuros;
        }
    }
}