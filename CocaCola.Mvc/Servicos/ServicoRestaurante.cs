using CocaCola.Mvc.Models.DTOs;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;

namespace CocaCola.Mvc.Servicos
{
    public class ServicoRestaurante : IServicoRestaurante
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicoRestaurante(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Adicionar(Restaurante restaurante)
        {
            await _unitOfWork.repositorioRestaurante.Adicionar(restaurante);
        }

        public void AtualizarRestaurante(Restaurante restaurante)
        {
            _unitOfWork.repositorioRestaurante.Atualizar(restaurante);
            _unitOfWork.Commit();
        }

        public async Task<Restaurante?> BuscarPorCnpj(string cnpj)
        {
            return await _unitOfWork.repositorioRestaurante.BuscarPorIdAsync(cnpj);
        }

        public async Task<Restaurante?> BuscarPorIdAsync(int id)
        {
            return await _unitOfWork.repositorioRestaurante.BuscarPorIdAsync(id);
        }

        public async Task<Restaurante?> BuscarRestaurantePorCnpjComVendas(RestauranteDTO restaurante)
        {
            if (restaurante.Cnpj == null){
                return null;
            } 
            return await _unitOfWork.repositorioRestaurante.BuscarRestaurantePorCnpjComVendas(restaurante.Cnpj);
        }

        public async Task<List<Restaurante>> BuscarTodosAsync()
        {
            return await _unitOfWork.repositorioRestaurante.BuscarTodosAsync();
        }

        public async Task<bool> ExisteRestaurante(string cnpj)
        {
            return await _unitOfWork.repositorioRestaurante.ExisteRestaurante(cnpj);;
        }

        public async Task<bool> InserirAtualizarRestauranteViaPlanilha(string pathArquivo)
        {
            try
            {
                int row = 2;
                //CADASTRA TODOS OS RESTAURANTES SEM CADASTRO
                using(var excel = new ClosedXML.Excel.XLWorkbook(pathArquivo))
                {
                    var planilha = excel.Worksheet(1).RowsUsed();
                    foreach (var linha in planilha)
                    {
                        if (linha.RowNumber() > 1 && !linha.IsEmpty())
                        {
                            var cnpj = linha.Cell("D").Value.ToString();
                            if (!await _unitOfWork.repositorioRestaurante.ExisteRestaurante(cnpj))
                            {
                                var razaoSocial = linha.Cell("E").Value.ToString();
                                var cidade = linha.Cell("C").Value.ToString();
                                var uf = linha.Cell("B").Value.ToString();
                                var nomeRede = linha.Cell("M").Value;  
                                Rede? rede;
                                var restaurante = new Restaurante() 
                                {
                                    Cnpj = cnpj, 
                                    RazaoSocial = razaoSocial,
                                    Cidade = cidade,
                                    Uf = uf,
                                };

                                if (nomeRede.IsBlank == false) 
                                {
                                    rede = await _unitOfWork.repositorioRede.BuscarRedePorNome(nomeRede.ToString()); 
                                    restaurante.Rede = rede; 
                                } 

                                await _unitOfWork.repositorioRestaurante.Adicionar(restaurante);
                                await _unitOfWork.Commit();
                            }
                        }
                        row++;
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}