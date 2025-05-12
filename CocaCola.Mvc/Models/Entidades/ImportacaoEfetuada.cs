namespace CocaCola.Mvc.Models.Entidades
{
    public class ImportacaoEfetuada
    {
        public int Id { get; set; } 
        public string NomeArquivoServer  { get; set; } = $"{Guid.NewGuid().ToString()}.xlsx";
        public string? NomeArquivo  { get; set; } 
        public DateTime DataImportacao { get; set; } = DateTime.UtcNow; 
        public ImportacaoEfetuada()
        {
        }

        public ImportacaoEfetuada(string? nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }
    }
}