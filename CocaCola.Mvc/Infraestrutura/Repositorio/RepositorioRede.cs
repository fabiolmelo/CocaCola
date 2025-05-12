using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.Mvc.Infraestrutura.Repositorio
{
    public class RepositorioRede : IRepositorioRede
    {
        private readonly DataContext _contexto;

        public RepositorioRede(DataContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Rede?> BuscarRedePorNome(string nome)
        {
            return await _contexto.Redes.Where(x => x.Nome == nome).FirstOrDefaultAsync();
        }

        public async Task Salvar(Rede rede)
        {
            await _contexto.Redes.AddAsync(rede); 
        }

        public async Task SalvarRedeContato(RedeContato redeContato)
        {
            await _contexto.RedesContato.AddAsync(redeContato);
        }
    }
}