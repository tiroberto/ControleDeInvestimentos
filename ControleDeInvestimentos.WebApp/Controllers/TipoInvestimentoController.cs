using Aplicacao;
using Aplicacao.NotificationPattern;
using Dominio;
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
    public class TipoInvestimentoController : Controller
    {
        private readonly TipoInvestimentoAplicacao appTipoInvestimento;

        public TipoInvestimentoController()
        {
            appTipoInvestimento = new TipoInvestimentoAplicacao();
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<TipoInvestimento>> Listar() => await appTipoInvestimento.Listar();

        [HttpGet("listarum")]
        [EnableCors]
        public TipoInvestimento ListarPorId(int id)
        {
            return appTipoInvestimento.ListarPorId(id);
        }

        [HttpPost("salvar")]
        public NotificationResult Salvar(TipoInvestimento tipoInvestimento)
        {
            return appTipoInvestimento.Salvar(tipoInvestimento);
        }

        [HttpDelete("excluir")]
        public string Excluir(int id)
        {
            return appTipoInvestimento.Excluir(id);
        }
    }
}
