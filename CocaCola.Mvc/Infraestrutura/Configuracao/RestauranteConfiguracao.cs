using CocaCola.Mvc.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocaCola.Mvc.Infraestrutura.Configuracao
{
    public class RestauranteConfiguracao : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cnpj).HasMaxLength(14);
            builder.Property(x => x.Uf).HasMaxLength(2);
            builder.Property(x => x.Cidade).HasMaxLength(100);
            
            builder.HasMany(r=>r.ExtratoVendas)
                   .WithOne(e=>e.Restaurante)
                   .HasForeignKey(e=>e.RestauranteId);
        }
    }
}