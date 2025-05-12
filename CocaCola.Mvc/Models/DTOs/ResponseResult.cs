namespace CocaCola.Mvc.Models.DTOs
{
    public class ResponseResult<T> where T : class
    {
        public ResponseResult(T? dados)
        {
            Dados = dados;
            Sucesso = true;
        }

        public ResponseResult(string? erro)
        {
            Erro = erro;
            Sucesso = false;
        }

        public bool Sucesso { get; set; }
        public T? Dados { get; set; }
        public string? Erro { get; set; }
    }
}