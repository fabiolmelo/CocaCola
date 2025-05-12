using CocaCola.Mvc.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocaCola.Mvc.Infraestrutura.Configuracao
{
    public class RedeConfiguracao : IEntityTypeConfiguration<Rede>
    {
        public void Configure(EntityTypeBuilder<Rede> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Nome).HasMaxLength(50);
            builder.HasMany(res => res.Restaurantes)
                   .WithOne(re => re.Rede)
                   .HasForeignKey(k => k.RedeId);   
        }
    }
}