using CocaCola.Mvc.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocaCola.Mvc.Infraestrutura.Configuracao
{
    public class ExtratoVendaConfiguracao : IEntityTypeConfiguration<ExtratoVenda>
    {
        public void Configure(EntityTypeBuilder<ExtratoVenda> builder)
        {
            builder.HasKey(x => new {x.Ano, x.Mes, x.RestauranteId});
            builder.Property(x=>x.IncidenciaReal).HasPrecision(2);
            builder.Property(x=>x.Meta).HasPrecision(2);
            builder.Property(x=>x.PrecoUnitarioMedio).HasPrecision(2);
            builder.Property(x=>x.ReceitaNaoCapturada).HasPrecision(2);
        }
    }
}