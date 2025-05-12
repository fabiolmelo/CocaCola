using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces.IRepositorio
{
    public interface IRepositorioImportacaoEfetuada
    {
        Task<ImportacaoEfetuada?> BuscarPorIdAsync(int id);
        Task<List<ImportacaoEfetuada>> BuscarTodosASync();
        Task<bool> Salvar(ImportacaoEfetuada importacaoEfetuada);
    }
}