using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocaCola.Mvc.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocaCola.Mvc.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoRedeContato _servicoRedeContato;

        public ServicosController(IServicoRedeContato servicoRedeContato)
        {
            _servicoRedeContato = servicoRedeContato;
        }

        [HttpPost]
        [Route("Contato/Aceite/{Token}")]
        public async Task<ActionResult> AceiteContato([FromQuery] Guid Token){
            var contato = await _servicoRedeContato.BuscarContatoPorToken(Token);
            if (contato == null){
                return BadRequest();
            }
            contato.DataAceite = DateTime.Now;
            contato.AceitaMensagem = true;
            _servicoRedeContato.Atualizar(contato);
            return Ok();
        }

        [HttpPost]
        [Route("Contato/Recusa/{Token}")]
        public async Task<ActionResult> RecusaContato([FromQuery] Guid Token){
            var contato = await _servicoRedeContato.BuscarContatoPorToken(Token);
            if (contato == null){
                return BadRequest();
            }
            contato.DataRecusa = DateTime.Now;
            contato.RecusaMensagem = true;
            contato.AceitaMensagem = false;
            _servicoRedeContato.Atualizar(contato);
            return Ok();
        }
    }
}