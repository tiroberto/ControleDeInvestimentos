using Aplicacao;
using Aplicacao.NotificationPattern;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace ControleDeInvestimentos.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarteiraController : Controller
    {
        private readonly CarteiraAplicacao appCarteira;

        public CarteiraController()
        {
            appCarteira = new CarteiraAplicacao();
        }

        [HttpGet("quantidadeinvestimentos")]
        [EnableCors]
        public int ListarQuantidadeInvestimentos(int idCarteira)
        {
            return appCarteira.ListarQuantidadeInvestimentos(idCarteira);
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Carteira>> Listar() => await appCarteira.Listar();

        [HttpGet("listarum")]
        [EnableCors]
        public Carteira ListarPorId(int id)
        {
            return appCarteira.ListarPorId(id);
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

        [HttpPost("adicionar-investimento")]
        public NotificationResult AddInvestimento(Investimento investimento)
        {
            return appCarteira.AdicionarInvestimento(investimento);
        }

        [HttpPost("salvar")]
        public NotificationResult Salvar(Carteira carteira)
        {
            return appCarteira.Salvar(carteira);
        }

        [HttpDelete("excluir")]
        public string Excluir(int id)
        {
            return appCarteira.Excluir(id);
        }
    }
}
