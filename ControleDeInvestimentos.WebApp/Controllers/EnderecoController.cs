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
    public class EnderecoController : Controller
    {
        private readonly EnderecoAplicacao appEndereco;

        public EnderecoController()
        {
            appEndereco = new EnderecoAplicacao();
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Endereco>> Listar() => await appEndereco.Listar();

        [HttpGet("listarum")]
        [EnableCors]
        public Endereco ListarPorId(int id)
        {
            return appEndereco.ListarPorId(id);
        }

        [HttpPost("salvar")]
        public NotificationResult Salvar(Endereco endereco)
        {
            return appEndereco.Salvar(endereco);
        }

        [HttpDelete("excluir")]
        public string Excluir(int id)
        {
            return appEndereco.Excluir(id);
        }
    }
}
