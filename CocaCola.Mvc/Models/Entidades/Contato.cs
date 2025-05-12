namespace CocaCola.Mvc.Models.Entidades
{
    public class Contato
    {
        public string Telefone { get; set; } 
        public string? Nome { get; set; }
        public ICollection<Rede>? Redes { get; set; }
        public bool AceitaMensagem {get; set; }
        public DateTime? DataAceite { get; set; }
        public bool RecusaMensagem {get; set; }
        public DateTime? DataRecusa { get; set; }
        public string? Email { get; set; }
        public Guid Token { get; set; } = Guid.NewGuid();

        public Contato(string telefone)
        {
            Telefone = telefone;
        }
    }
}