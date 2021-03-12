namespace APICalculaJuros.Domains
{
    public class JurosCompostos
    {
        public float ValorInicial { get; } 
        public int Meses { get; }
        public float ValorJuros { get; set; }     

        public JurosCompostos(float valorinicial, int meses)        
        {
            ValorInicial = valorinicial;
            Meses = meses;            
        }   
    }
}