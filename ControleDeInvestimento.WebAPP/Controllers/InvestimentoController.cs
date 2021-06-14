using Aplicacao;
using Aplicacao.NotificationPattern;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeInvestimentos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly InvestimentoAplicacao appInvestimento;

        public InvestimentoController()
        {
            appInvestimento = new InvestimentoAplicacao();
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Investimento>> Listar() => appInvestimento.Listar().ToArray();

        [HttpGet("listarum")]
        [EnableCors]
        public Investimento ListarPorId(int id)
        {
            return appInvestimento.ListarPorId(id);
        }

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //[EnableCors]
        //public async Task<IActionResult> Authenticate([FromBody] Cliente userParam)
        //{
        //    var usuario = await _clienteServico.Authenticate(userParam.UsuarioLogin, userParam.SenhaLogin);

        //    if (usuario == null)
        //        return BadRequest(new { message = "Usuário ou senha incorreto" });

        //    return Ok(usuario);
        //}

        [HttpPost("salvar")]
        public NotificationResult Salvar(Investimento investimento)
        {
            return appInvestimento.Salvar(investimento);
        }

        [HttpDelete]
        public string Excluir(Investimento investimento)
        {
            return appInvestimento.Excluir(investimento.InvestimentoId);
        }
    }
}
