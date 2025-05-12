using CocaCola.Mvc.Infraestrutura.Repositorio;
using CocaCola.Mvc.Infraestrutura.Repositorio.UnitOfWork;
using CocaCola.Mvc.Models.Interfaces;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using CocaCola.Mvc.Servicos;
using CocaCola.MVC.Infraestrutura.Repositorio;
using CocaCola.MVC.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;

namespace CocaCola.WebApi.Extensoes
{
    public static class RegistrarServicos
    {
        public static void AdicionarServicosAppIOC(this IServiceCollection servicos)
        {
            servicos.AddScoped<IRepositorioImportacaoEfetuada, RepositorioImportacaoEfetuada>();
            servicos.AddScoped<IRepositorioExtratoVendas, RepositorioExtratoVenda>();
            servicos.AddScoped<IRepositorioRestaurante, RepositorioRestaurante>();
            servicos.AddScoped<IRepositorioContato, RepositorioContato>();
            servicos.AddScoped<IRepositorioRede, RepositorioRede>();
            servicos.AddScoped<IServicoArquivos, ServicoArquivo>();
            servicos.AddScoped<IServicoExtratoVenda, ServicoExtratoVenda>();
            servicos.AddScoped<IServicoRestaurante, ServicoRestaurante>();
            servicos.AddScoped<IServicoRedeContato, ServicoRedeContato>();
            servicos.AddScoped<IServicoProcessamentoMensal, ServicoProcessamentoMensal>();
            servicos.AddScoped<IServicoMeta, ServicoMeta>();
            servicos.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}