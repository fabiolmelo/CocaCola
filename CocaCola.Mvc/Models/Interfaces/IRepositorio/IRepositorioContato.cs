using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces.IRepositorio
{
    public interface IRepositorioContato
    {
        Task<Contato?> BuscarContatoPorId(string telefone);
        Task<Contato?> BuscarContatoPorToken(Guid token);
        Task<ICollection<Contato>> BuscarTodosContatos();
        Task SalvarContato(Contato contato);
        void AtualizarContato(Contato contato);
    }
}