using CocaCola.Mvc.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocaCola.Mvc.Controllers
{
    public class ImportarArquivoController : Controller
    {
        private readonly IServicoArquivos _servicoArquivos;
        private readonly IServicoRestaurante _servicoRestaurante;
        private readonly IServicoExtratoVenda _servicoExtratoVenda;
        private readonly IServicoRedeContato _servicoRedeContato;
        public ImportarArquivoController(IServicoArquivos servicoArquivos,
                                         IServicoRestaurante servicoRestaurante,
                                         IServicoExtratoVenda servicoExtratoVenda,
                                         IServicoRedeContato servicoRedeContato)
        {
            _servicoArquivos = servicoArquivos;
            _servicoRestaurante = servicoRestaurante;
            _servicoExtratoVenda = servicoExtratoVenda;
            _servicoRedeContato = servicoRedeContato;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile arquivoEnviado)
        {
            var arquivoImportado = await  _servicoArquivos.UploadArquivo(arquivoEnviado);
            if (arquivoImportado == null)
                return BadRequest();
            await _servicoRedeContato.InserirAlterarRedeContato(arquivoImportado);
            await _servicoRestaurante.InserirAtualizarRestauranteViaPlanilha(arquivoImportado);
            await _servicoExtratoVenda.InserirAlterarExtratoVendas(arquivoImportado);
            return View();
        }
    }
}