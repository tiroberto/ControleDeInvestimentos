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
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : Controller
    {
        private readonly CarteiraAplicacao appCarteira;

        public CarteiraController()
        {
            appCarteira = new CarteiraAplicacao();
        }

        [HttpGet("listar")]
        public IEnumerable<Carteira> Listar() => appCarteira.Listar();

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

        [HttpPost("salvar")]
        public NotificationResult Salvar(Carteira carteira)
        {
            return appCarteira.Salvar(carteira);
        }

        [HttpDelete]
        public string Excluir(Carteira carteira)
        {
            return appCarteira.Excluir(carteira.CarteiraId);
        }
    }
}
