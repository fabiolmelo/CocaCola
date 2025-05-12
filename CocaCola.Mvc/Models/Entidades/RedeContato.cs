namespace CocaCola.Mvc.Models.Entidades
{
    public class RedeContato
    {
        public int RedeId { get; set;}
        public string ContatoTelefone { get; set; } = String.Empty ;
        public Rede Rede { get; set; } = null!;
        public Contato Contato { get; set; } = null!;

    }
}