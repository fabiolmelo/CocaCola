using CocaCola.Mvc.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocaCola.Mvc.Infraestrutura.Configuracao
{
    public class ImportacaoEfetuadaConfiguracao : IEntityTypeConfiguration<ImportacaoEfetuada>
    {
        public void Configure(EntityTypeBuilder<ImportacaoEfetuada> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeArquivoServer).HasMaxLength(255);
            builder.Property(x => x.NomeArquivo).HasMaxLength(255);
            builder.Property(x => x.DataImportacao).HasMaxLength(255);
        }
    }
}