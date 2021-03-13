namespace APICalculaJuros.Domains
{
    public class JurosCompostos
    {
        public double ValorInicial { get; } 
        public int Meses { get; }
        public double TaxaJuros { get; }
        
        public JurosCompostos(double valorinicial, int meses, double taxajuros)        
        {
            ValorInicial = valorinicial;
            Meses = meses;   
            TaxaJuros = taxajuros;         
        }   
    }
}