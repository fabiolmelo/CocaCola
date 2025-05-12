using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.MVC.Models.Interfaces
{
    public interface IServicoArquivos
    {
        Task<string?> UploadArquivo(IFormFile arquivo);
        Task<List<ImportacaoEfetuada>> BuscarTodasImportacoes();
        byte[] GerarArquivoPdf(Restaurante restaurante);
    }
}