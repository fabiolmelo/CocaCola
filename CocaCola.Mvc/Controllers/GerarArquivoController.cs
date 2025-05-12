using CocaCola.Mvc.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocaCola.Mvc.Controllers
{
    public class GerarArquivoController : Controller
    {
        private readonly IServicoProcessamentoMensal _servicoProcessamentoMensal;

        public GerarArquivoController(IServicoProcessamentoMensal servicoProcessamentoMensal)
        {
            _servicoProcessamentoMensal = servicoProcessamentoMensal;
        }

        public async Task<IActionResult> Index()
        {
            string cnpj = "24840166012867";
            DateTime competencia = DateTime.Parse("31/07/2024");
            var processamento = await _servicoProcessamentoMensal.BuscarProcessamento(cnpj, competencia);
            return View(processamento);
        }
    }
}