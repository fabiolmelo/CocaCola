using CocaCola.Mvc.Infraestrutura.Configuracao;
using CocaCola.Mvc.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CocaCola.Mvc.Infraestrutura.Contexto
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DataContext(DbContextOptions<DataContext> options, 
                           IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ExtratoVenda> ExtratosVendas { get; set; }
        public DbSet<ImportacaoEfetuada> ImportacoesEfetuadas { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Rede> Redes { get; set; }
        public DbSet<RedeContato> RedesContato { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("WebApiSqlLiteDatabase");
            dbContextOptionsBuilder.UseSqlite(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImportacaoEfetuadaConfiguracao());
            modelBuilder.ApplyConfiguration(new ExtratoVendaConfiguracao());
            modelBuilder.ApplyConfiguration(new RestauranteConfiguracao());
            modelBuilder.ApplyConfiguration(new ContatoConfiguracao());
            modelBuilder.ApplyConfiguration(new RedeConfiguracao());
        }
    }
}