using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces;
using CocaCola.MVC.Models.Interfaces.IUnitOfWork;

namespace CocaCola.Mvc.Servicos
{
    public class ServicoRedeContato : IServicoRedeContato
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicoRedeContato(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(Contato contato)
        {
            _unitOfWork.repositorioContato.AtualizarContato(contato);
            _unitOfWork.Commit();
        }

        public async Task<Contato?> BuscarContatoPorId(string telefone)
        {
            return await _unitOfWork.repositorioContato.BuscarContatoPorId(telefone);
        }

        public async Task<Contato?> BuscarContatoPorToken(Guid token)
        {
            return await _unitOfWork.repositorioContato.BuscarContatoPorToken(token);
        }

        public async Task<Rede?> BuscarRedePorNome(string nome)
        {
            return await _unitOfWork.repositorioRede.BuscarRedePorNome(nome);
        }

        public async Task<ICollection<Contato>> BuscarTodosContatos()
        {
            return await _unitOfWork.repositorioContato.BuscarTodosContatos();
        }

        public async Task<bool> InserirAlterarRedeContato(string pathArquivo)
        {
            try
            {
                int row = 2;
                //CADASTRA TODAS AS REDES SEM CADASTRO
                using(var excel = new ClosedXML.Excel.XLWorkbook(pathArquivo))
                {
                    var planilha = excel.Worksheet(1).RowsUsed();
                    foreach (var linha in planilha)
                    {
                        if (linha.RowNumber() > 1 && !linha.IsEmpty())
                        {
                            var redeDto = linha.Cell("M").Value;
                            var telefoneDto = linha.Cell("N").Value;
                            Contato? contato;
                            Rede? rede;
                           
                            if (!redeDto.IsBlank){
                                rede = await _unitOfWork.repositorioRede.BuscarRedePorNome(redeDto.ToString());
                                if (rede == null){
                                    rede = new Rede(redeDto.ToString());
                                    await _unitOfWork.repositorioRede.Salvar(rede);
                                    await _unitOfWork.Commit();
                                }
                            }
                            
                            if (!telefoneDto.IsBlank){
                                contato = await _unitOfWork.repositorioContato.BuscarContatoPorId(telefoneDto.ToString());
                                if (contato == null){
                                    contato = new Contato(telefoneDto.ToString());
                                    await _unitOfWork.repositorioContato.SalvarContato(contato);
                                    await _unitOfWork.Commit();
                                }
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

        public async Task InserirContato(Contato contato)
        {
            await _unitOfWork.repositorioContato.SalvarContato(contato);
        }

        public async Task InserirRede(Rede rede)
        {
            await _unitOfWork.repositorioRede.Salvar(rede);
        }
    }
}