using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces
{
    public interface IServicoExtratoVenda
    {
        Task<List<ExtratoVenda>> BuscarTodosExtratos(); 
        Task<bool> ExisteExtratoVenda(int ano, int mes, string cnpj);
        Task<bool> InserirAlterarExtratoVendas(string pathArquivo);
    }
}