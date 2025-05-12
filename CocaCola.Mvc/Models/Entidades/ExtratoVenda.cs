namespace CocaCola.Mvc.Models.Entidades
{
    public class ExtratoVenda
    {
        public int Ano { get; set; }        
        public int Mes { get; set; }        
        public DateTime Competencia { get; set; } 
        public int TotalPedidos { get; set; }
        public int PedidosComCocaCola { get; set; }
        public decimal IncidenciaReal { get; set; }    
        public decimal Meta { get; set; }   
        public decimal PrecoUnitarioMedio { get; set; }   
        public int TotalPedidosNaoCapturados { get; set; }    
        public decimal ReceitaNaoCapturada { get; set; }
        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; } = new Restaurante();  
        public ExtratoVenda()
        {
        }    
    }
}