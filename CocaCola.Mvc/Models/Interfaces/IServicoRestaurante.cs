using CocaCola.Mvc.Models.DTOs;
using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces
{
    public interface IServicoRestaurante
    {
        Task<bool> ExisteRestaurante(string cnpj);
        Task Adicionar(Restaurante restaurante);
        Task<Restaurante?> BuscarPorCnpj(string cnpj);
        Task<Restaurante?> BuscarPorIdAsync(int id);
        Task<List<Restaurante>> BuscarTodosAsync();
        Task<Restaurante?> BuscarRestaurantePorCnpjComVendas(RestauranteDTO restaurante);
        Task<bool> InserirAtualizarRestauranteViaPlanilha(string pathArquivo);
        void AtualizarRestaurante(Restaurante restaurante);
        
    }
}