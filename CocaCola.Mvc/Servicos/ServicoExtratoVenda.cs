using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;

namespace CocaCola.Mvc.Servicos
{
    public class ServicoExtratoVenda : IServicoExtratoVenda
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicoExtratoVenda(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExtratoVenda>> BuscarTodosExtratos()
        {
            return await _unitOfWork.repositorioExtratoVendas.BuscarTodosASync();
        }

        public async Task<bool> ExisteExtratoVenda(int ano, int mes, string cnpj)
        {
            return await _unitOfWork.repositorioExtratoVendas.ExisteExtratoVenda(ano, mes, cnpj);
        }

        public async Task<bool> InserirAlterarExtratoVendas(string pathArquivo)
        {
            int row = 2;
            using(var excel = new ClosedXML.Excel.XLWorkbook(pathArquivo))
            {
                var planilha = excel.Worksheet(1).RowsUsed();
                foreach (var linha in planilha)
                {
                    if (linha.RowNumber() > 1 && !linha.IsEmpty())
                    {
                        var cnpj = linha.Cell("D").Value.ToString();
                        var data = linha.Cell("A").Value.GetDateTime();
                        int ano = data.Year; 
                        int mes = data.Month;
                        var incidencia = (decimal)linha.Cell("H").Value.GetNumber();
                        var meta = (decimal)linha.Cell("I").Value.GetNumber();
                        var precoUnitarioMedio = (decimal)linha.Cell("J").Value.GetNumber();
                        var qtdPedidosNaoCapiturados = (int)linha.Cell("K").Value;
                        var receitaNaoCapturada = (decimal)linha.Cell("L").Value.GetNumber();
                        var restauranteCnpj = cnpj;

                        var extratoVenda = new ExtratoVenda()
                        {
                            Ano = ano,
                            Mes = mes,
                            Competencia = data,
                            TotalPedidos = (int)linha.Cell("F").Value,
                            PedidosComCocaCola = (int)linha.Cell("G").Value,
                            IncidenciaReal = incidencia,
                            Meta = meta,
                            PrecoUnitarioMedio = precoUnitarioMedio,
                            TotalPedidosNaoCapturados = qtdPedidosNaoCapiturados,
                            ReceitaNaoCapturada = receitaNaoCapturada
                        };

                        if (await _unitOfWork.repositorioExtratoVendas.ExisteExtratoVenda(ano, mes, cnpj))
                        {
                            extratoVenda = await _unitOfWork.repositorioExtratoVendas.
                                                BuscarPorIdAsync(ano, mes, cnpj); 
                        }

                        var restaurante = await _unitOfWork.repositorioRestaurante.BuscarPorIdAsync(cnpj);
                        if(restaurante != null)
                        {
                            restaurante.AdicionarExtrato(extratoVenda);
                            _unitOfWork.repositorioRestaurante.Atualizar(restaurante);
                            await _unitOfWork.Commit();
                        }
                    }
                    row++;
                }
            }
            return true;
        }
    }
}