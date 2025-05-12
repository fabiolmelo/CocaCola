using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.Mvc.Infraestrutura.Repositorio
{
    public class RepositorioRestaurante : IRepositorioRestaurante
    {
        private readonly DataContext _contexto;

        public RepositorioRestaurante(DataContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Restaurante restaurante)
        {
            await _contexto.Restaurantes.AddAsync(restaurante);
        }

        public void Atualizar(Restaurante restaurante)
        {
            _contexto.Restaurantes.Update(restaurante);
        }

        public async Task<Restaurante?> BuscarPorIdAsync(int id)
        {
            return await _contexto.Restaurantes.FindAsync(id);
        }

        public async Task<Restaurante?> BuscarPorIdAsync(string cnpj)
        {
            return await _contexto.Restaurantes.AsNoTracking().
                         Where(x => x.Cnpj == cnpj).FirstOrDefaultAsync();
        }

        public async Task<Restaurante?> BuscarRestaurantePorCnpjComVendas(string cnpj)
        {
            return await _contexto.Restaurantes.AsNoTracking().
                         Include(x=>x.ExtratoVendas).Where(x=>x.Cnpj == cnpj).FirstOrDefaultAsync();
        }

        public async Task<List<Restaurante>> BuscarTodosAsync()
        {
            return await _contexto.Restaurantes.AsNoTracking().ToListAsync();
        }

        public async Task<bool> ExisteRestaurante(string cnpj)
        {
            return await _contexto.Restaurantes.AsNoTracking().AnyAsync(x => x.Cnpj == cnpj);
        }
    }
}