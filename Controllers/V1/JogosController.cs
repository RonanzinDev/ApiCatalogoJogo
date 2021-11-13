using System.ComponentModel.DataAnnotations;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatologoJogos.Controller.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoServices _jogoServices;
        public JogosController(IJogoServices jogoservices)
        {
            _jogoServices = jogoservices;
        }
        [HttpGet]
        // quantidade = é a quantidade de itens que a pagina pode ter
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoServices.Obter(pagina, quantidade);
            if (jogos.Count() == 0) return NoContent();
            return Ok(jogos);
        }
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<object>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoServices.Obter(idJogo);
            if (jogo == null) return NoContent();
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo)
        {
            return Ok();
        }
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, object jogo)
        {
            return Ok();
        }
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid id)
        {
            return Ok();
        }

    }
}