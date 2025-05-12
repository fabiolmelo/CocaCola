using CocaCola.Mvc.Models.Entidades;

namespace CocaCola.Mvc.Models.Interfaces.IRepositorio
{
    public interface IRepositorioRestaurante
    {
        Task<bool> ExisteRestaurante(string cnpj);
        Task Adicionar(Restaurante restaurante);
        Task<Restaurante?> BuscarPorIdAsync(int id);
        Task<Restaurante?> BuscarPorIdAsync(string cnpj);
        Task<List<Restaurante>> BuscarTodosAsync();
        void Atualizar(Restaurante restaurante);
        Task<Restaurante?> BuscarRestaurantePorCnpjComVendas(string cnpj);
    }
}