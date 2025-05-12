
using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces.IRepositorio
{
    public interface IRepositorioExtratoVendas
    {
        Task<ExtratoVenda?> BuscarPorIdAsync(int id);
        Task<ExtratoVenda> BuscarPorIdAsync(int ano, int mes, string cnpj);
        Task<List<ExtratoVenda>> BuscarTodosASync();
        Task<bool> Adicionar(ExtratoVenda extratoVendas);
        Task<bool> AdicionarEmLote(List<ExtratoVenda> extratosVendas);
        Task SaveChangesASync();
        Task<bool> ExisteExtratoVenda(int ano, int mes, string cnpj);
    }
}