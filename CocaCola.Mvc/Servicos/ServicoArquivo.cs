using CocaCola.Mvc.Models.Entidades;
using CocaCola.MVC.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;
using iTextSharp.text;

namespace CocaCola.Mvc.Servicos
{
    public class ServicoArquivo : IServicoArquivos
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServicoArquivo(IUnitOfWork unitOfWork, 
                              IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<ImportacaoEfetuada>> BuscarTodasImportacoes()
        {
            return await _unitOfWork.repositorioImportacaoEfetuada.BuscarTodosASync();
        }

        public async Task<string?> UploadArquivo(IFormFile arquivo)
        {
            if (arquivo.Length == 0){
                return null;
            }
            var arquivoImportado = new ImportacaoEfetuada(arquivo.FileName);
            var diretorio = Path.Combine(_webHostEnvironment.ContentRootPath, "DadosApp\\Planilhas");
            var filePath = Path.Combine(diretorio, arquivoImportado.NomeArquivoServer.ToString());
            var importacaoEfetuada = new ImportacaoEfetuada(filePath);

            try
            {
                using (FileStream filestream = System.IO.File.Create(filePath)){
                    await arquivo.CopyToAsync(filestream);
                    filestream.Flush();
                }
                // await _unitOfWork.repositorioImportacaoEfetuada.Salvar(importacaoEfetuada);
                // await _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                return null;
            }
            return filePath;
        }
        public byte[] GerarArquivoPdf(Restaurante restaurante)
        {
            byte[] arquivoPdf = new byte[10];
            var caminhoFundo = Path.Combine(_webHostEnvironment.ContentRootPath, 
                                           "DadosApp\\CocaColaFundo.jpeg");
            var caminhoPDF = caminhoFundo.Replace("jpeg","pdf");
            using(var image = System.IO.File.OpenRead(caminhoFundo)){
                using(FileStream fileStream = new FileStream(caminhoPDF, FileMode.Truncate)){
                    Document document = new Document(PageSize.A4);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream);
                    document.Open();
                    var pic = iTextSharp.text.Image.GetInstance(caminhoFundo);
                    pic.SetAbsolutePosition(0,0);
                    pic.ScaleToFit(document.PageSize); 
                    document.Add(pic);
                    fileStream.Flush();
                    document.CloseDocument();
                }
            }
            return arquivoPdf;
        }
    }
}