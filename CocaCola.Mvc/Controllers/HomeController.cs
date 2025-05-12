using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CocaCola.Mvc.Models;
using CocaCola.MVC.Models.Interfaces;

namespace CocaCola.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IServicoArquivos _servicoArquivos;

    public HomeController(ILogger<HomeController> logger, 
                          IServicoArquivos servicoArquivos)
    {
        _logger = logger;
        _servicoArquivos = servicoArquivos;
    }

    public IActionResult Index()
    {
        var imp = _servicoArquivos.BuscarTodasImportacoes();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
