using CocaCola.Mvc.Infraestrutura.Contexto;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.Mvc.Infraestrutura.Repositorio
{
    public class RepositorioContato : IRepositorioContato
    {
        private readonly DataContext _contexto;

        public RepositorioContato(DataContext contexto)
        {
            _contexto = contexto;
        }

        public void AtualizarContato(Contato contato)
        {
            _contexto.Contatos.Update(contato);
        }

        public async Task<Contato?> BuscarContatoPorId(string telefone)
        {
            return await _contexto.Contatos.FindAsync(telefone);
        }

        public async Task<Contato?> BuscarContatoPorToken(Guid token)
        {
            return await _contexto.Contatos.Where(x=> x.Token == token).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Contato>> BuscarTodosContatos()
        {
            return await _contexto.Contatos.ToListAsync();
        }

        public async Task SalvarContato(Contato contato)
        {
            await _contexto.Contatos.AddAsync(contato);
        }
    }
}