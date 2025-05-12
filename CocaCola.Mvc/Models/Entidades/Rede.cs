namespace CocaCola.Mvc.Models.Entidades
{
    public class Rede
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Restaurante> Restaurantes { get; set; }
        public ICollection<Contato> Contatos { get; set; }
        public Rede(string nome)
        {
            Restaurantes = new List<Restaurante>();
            Contatos = new List<Contato>();
            Nome = nome;
        }
    }
}