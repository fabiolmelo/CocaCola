using CocaCola.Mvc.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocaCola.Mvc.Infraestrutura.Configuracao
{
    public class ContatoConfiguracao : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Telefone);
            builder.HasMany(r=>r.Redes).
                    WithMany(c=>c.Contatos).
                    UsingEntity<RedeContato>();
            builder.Property(x=>x.Token).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}