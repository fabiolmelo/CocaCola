namespace CocaCola.Mvc.Models.DTOs
{
    public class BoolResult
    {
        public BoolResult(bool retorno)
        {
            this.retorno = retorno;
        }
        public bool retorno { get; set; }
    }
}