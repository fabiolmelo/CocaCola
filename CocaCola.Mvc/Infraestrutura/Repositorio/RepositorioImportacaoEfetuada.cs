using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.Mvc.Infraestrutura.Repositorio
{
    public class RepositorioImportacaoEfetuada : IRepositorioImportacaoEfetuada
    {
        private readonly DataContext contexto;

        public RepositorioImportacaoEfetuada(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<ImportacaoEfetuada?> BuscarPorIdAsync(int id)

        {
            return await contexto.FindAsync<ImportacaoEfetuada>(id);
        }

        public async Task<List<ImportacaoEfetuada>> BuscarTodosASync()
        {
            return await contexto.ImportacoesEfetuadas.ToListAsync();
        }

        public async Task<bool> Salvar(ImportacaoEfetuada importacaoEfetuada)
        {
            await contexto.AddAsync(importacaoEfetuada);
            return true;
        }
    }
}