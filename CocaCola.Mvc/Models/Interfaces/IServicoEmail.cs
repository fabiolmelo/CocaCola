namespace CocaCola.Mvc.Models.Interfaces
{
    public interface IServicoEmail
    {
        Task<bool> EnviarEmailASync(string emailDestinatario);
    }
}