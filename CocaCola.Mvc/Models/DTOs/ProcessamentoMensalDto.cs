using System.ComponentModel.DataAnnotations;

namespace CocaCola.Mvc.Models.DTOs
{
    public class ProcessamentoMensalDto
    {
        [DataType(DataType.Date)]
        public DateTime Competencia { get; set; }
    }
}