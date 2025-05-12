using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.MVC.Infraestrutura.Repositorio
{
    public class RepositorioExtratoVenda : IRepositorioExtratoVendas
    {
        private readonly DataContext contexto;

        public RepositorioExtratoVenda(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<ExtratoVenda?> BuscarPorIdAsync(int id)
        {
            return await contexto.FindAsync<ExtratoVenda>(id);
        }

        public async Task<ExtratoVenda> BuscarPorIdAsync(int ano, int mes, string cnpj)
        {
            var extrato = await contexto.ExtratosVendas.Where(x => x.Ano == ano && 
                    x.Mes == mes && x.Restaurante.Cnpj == cnpj).FirstOrDefaultAsync();
            return extrato ?? new ExtratoVenda();
        }
        public async Task<List<ExtratoVenda>> BuscarTodosASync()
        {
            return await contexto.ExtratosVendas.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Adicionar(ExtratoVenda extratoVenda)
        {
            await contexto.ExtratosVendas.AddAsync(extratoVenda);
            return true;
        }

        public async Task<bool> AdicionarEmLote(List<ExtratoVenda> extratosVendas)
        {
            await contexto.ExtratosVendas.AddRangeAsync(extratosVendas);
            return true;
        }

        public async Task SaveChangesASync()
        {
            await contexto.SaveChangesAsync();
        }

        public async Task<bool> ExisteExtratoVenda(int ano, int mes, string cnpj)
        {
            return await contexto.ExtratosVendas.AnyAsync(x => x.Ano == ano && 
                   x.Mes == mes && x.Restaurante.Cnpj == cnpj);
        }
   }
}