namespace CocaCola.Mvc.Models.Entidades
{
    public class ProcessamentoMensalEnvio
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public Restaurante Restaurante { get; set; }
        public DateTime DataProcessamnto { get; set; } = DateTime.UtcNow;
        public bool Enviado { get; set; } = false;
        public DateTime? DataEnvio { get; set; }
        public ProcessamentoMensalEnvio(int ano, int mes, Restaurante restaurante)
        {
            Ano = ano;
            Mes = mes;
            Restaurante = restaurante;
        }
    }
}