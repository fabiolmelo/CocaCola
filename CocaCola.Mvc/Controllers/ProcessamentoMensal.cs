using CocaCola.Mvc.Models.DTOs;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocaCola.Mvc.Controllers
{
    [Route("[controller]")]
    public class ProcessamentoMensal : Controller
    {
        private readonly ILogger<ProcessamentoMensal> _logger;
        //private readonly IServicoProcessamentoMensal _servicoProcessamentoMensal;
        private readonly IServicoRestaurante _servicoRestaurante;

        private readonly IServicoRedeContato _servicoRedeContato;

        private readonly IServicoMeta _servicoMeta;

        public ProcessamentoMensal(ILogger<ProcessamentoMensal> logger,
                                   //IServicoProcessamentoMensal servicoProcessamentoMensal,
                                   IServicoRestaurante servicoRestaurante,
                                   IServicoRedeContato servicoRedeContato,
                                   IServicoMeta servicoMeta)
        {
            _logger = logger;
            //_servicoProcessamentoMensal = servicoProcessamentoMensal;
            _servicoRestaurante = servicoRestaurante;
            _servicoRedeContato = servicoRedeContato;
            _servicoMeta = servicoMeta;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contatos = await _servicoRedeContato.BuscarTodosContatos();
            var ArquivoMensal = new ArquivoMensal() {
                ArquivoPdf = "Teste"
            };
            foreach(Contato envio in contatos){
                await _servicoMeta.EnviarTesteASync(envio);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Gerar(ProcessamentoMensalDto processamentoMensalDto){
            //var sucesso = _servicoProcessamentoMensal.GerarProcessamentoMensal(processamentoMensalDto.Competencia);
            return View();
        }
    }
}