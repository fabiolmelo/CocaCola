using CocaCola.Mvc.Models.Interfaces.IRepositorio;

namespace CocaCola.MVC.Models.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork 
    {
        public IRepositorioImportacaoEfetuada repositorioImportacaoEfetuada { get; }
        public IRepositorioExtratoVendas  repositorioExtratoVendas { get; }
        public IRepositorioRestaurante  repositorioRestaurante { get; }
        public IRepositorioRede repositorioRede { get; }
        public IRepositorioContato repositorioContato { get; }
        Task Commit();
    }
}