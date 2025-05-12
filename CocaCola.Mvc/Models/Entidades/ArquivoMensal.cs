namespace CocaCola.Mvc.Models.Entidades
{
    public class ArquivoMensal
    {
        public DateTime Competencia { get; set; }
        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; } = new Restaurante();
        public string ArquivoPdf { get; set; } = string.Empty;
    }
}