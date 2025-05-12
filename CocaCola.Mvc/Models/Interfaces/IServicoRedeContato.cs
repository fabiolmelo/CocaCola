using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces
{
    public interface IServicoRedeContato
    {
        Task<bool> InserirAlterarRedeContato(string pathArquivo);
        Task InserirContato(Contato contato);
        Task InserirRede(Rede rede);
        Task<Contato?> BuscarContatoPorId(string telefone);
        Task<Contato?> BuscarContatoPorToken(Guid token);
        Task<Rede?> BuscarRedePorNome(string nome);
        void Atualizar(Contato contato);
        Task<ICollection<Contato>> BuscarTodosContatos();
    }
}