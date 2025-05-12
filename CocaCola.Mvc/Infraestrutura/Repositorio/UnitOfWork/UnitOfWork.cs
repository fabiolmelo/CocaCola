using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;

namespace CocaCola.Mvc.Infraestrutura.Repositorio.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext contexto;
        private readonly IRepositorioExtratoVendas _repositorioExtratoVendas;
        private readonly IRepositorioContato _repositorioContato;
        private readonly IRepositorioRestaurante _repositorioRestaurante;
        private readonly IRepositorioRede _repositorioRede;

        public UnitOfWork(DataContext contexto, IRepositorioExtratoVendas repositorioExtratoVendas, IRepositorioContato repositorioContato, IRepositorioRestaurante repositorioRestaurante, IRepositorioRede repositorioRede)
        {
            this.contexto = contexto;
            _repositorioExtratoVendas = repositorioExtratoVendas;
            _repositorioContato = repositorioContato;
            _repositorioRestaurante = repositorioRestaurante;
            _repositorioRede = repositorioRede;
        }

        public IRepositorioExtratoVendas repositorioExtratoVendas => _repositorioExtratoVendas;

        public IRepositorioRestaurante repositorioRestaurante => _repositorioRestaurante;

        public IRepositorioRede repositorioRede => _repositorioRede;

        public IRepositorioContato repositorioContato => _repositorioContato;

        public IRepositorioImportacaoEfetuada repositorioImportacaoEfetuada => throw new NotImplementedException();

        public async Task Commit()
        {
            await contexto.SaveChangesAsync();
            contexto.ChangeTracker.Clear();
        }
    }
}