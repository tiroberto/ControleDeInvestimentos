using Aplicacao;
using Aplicacao.NotificationPattern;
using Dominio.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeInvestimentos.WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioAplicacao appUsuario;

        public UsuarioController()
        {
            appUsuario = new UsuarioAplicacao();
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Usuario>> Listar() => await appUsuario.Listar();

        [HttpGet("listarum")]
        [EnableCors]
        public Usuario ListarPorId(int id)
        {
            return appUsuario.ListarPorId(id);
        }

        [HttpPost("salvar")]
        public NotificationResult Salvar(Usuario usuario)
        {
            return appUsuario.Salvar(usuario);
        }

        [HttpDelete("excluir")]
        public string Excluir(int id)
        {
            return appUsuario.Excluir(id);
        }
    }
}
