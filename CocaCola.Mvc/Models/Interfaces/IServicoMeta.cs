using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces
{
    public interface IServicoMeta
    {
        Task<bool> EnviarSolitacaoAceiteContatoASync(Contato contato);
        Task<bool> EnviarFechamentoMensalASync(Contato contato, ArquivoMensal arquivo);
        Task<bool> EnviarTesteASync(Contato contato);
    }
}