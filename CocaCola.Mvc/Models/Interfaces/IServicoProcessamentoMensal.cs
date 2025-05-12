using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces
{
    public interface IServicoProcessamentoMensal
    {
        bool GerarProcessamentoMensal(DateTime competencia);

        Task<Restaurante?> BuscarProcessamento(string cnpj, DateTime competencia);
    }
}