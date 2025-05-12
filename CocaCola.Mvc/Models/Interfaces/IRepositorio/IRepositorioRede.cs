using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces.IRepositorio
{
    public interface IRepositorioRede
    {
        Task<Rede?> BuscarRedePorNome(string nome);
        Task Salvar(Rede rede);
        Task SalvarRedeContato(RedeContato redeContato);

    }
}