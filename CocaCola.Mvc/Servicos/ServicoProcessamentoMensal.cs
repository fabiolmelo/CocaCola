using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.Mvc.Servicos
{
    public class ServicoProcessamentoMensal : IServicoProcessamentoMensal
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _dataContext;
        private readonly IServicoArquivos _servicoArquivos;

        public ServicoProcessamentoMensal(IUnitOfWork unitOfWork,
                                          DataContext dataContext,
                                          IServicoArquivos servicoArquivos)
        {
            _unitOfWork = unitOfWork;
            _dataContext = dataContext;
            _servicoArquivos = servicoArquivos;
        }

        public Task<Restaurante?> BuscarProcessamento(string cnpj, DateTime competencia)
        {
            throw new NotImplementedException();
        }

        public bool GerarProcessamentoMensal(DateTime competencia)
        {
            var ano = competencia.Year;
            var mes = competencia.Month;
            var restaurantes = _dataContext.Restaurantes.
                                Include(x => x.ExtratoVendas.Where(e=>e.Ano == ano && e.Mes <= mes))
                                .Where(r=>r.Cnpj=="24840166012867")
                                .ToList();
            foreach(Restaurante restaurante in restaurantes){
                _servicoArquivos.GerarArquivoPdf(restaurante);
            }
            return true;
        }
    }
}