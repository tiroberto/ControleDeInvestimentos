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
    public class TodosInvestimentosController : Controller
    {
        private readonly TodosInvestimentosAplicacao appTodosInvestimentos;

        public TodosInvestimentosController()
        {
            appTodosInvestimentos = new TodosInvestimentosAplicacao();
        }

        [HttpGet("listar")]
        public IEnumerable<TodosInvestimentos> Listar() => appTodosInvestimentos.Listar();

        [HttpGet("listarum")]
        [EnableCors]
        public TodosInvestimentos ListarPorId(int id)
        {
            return appTodosInvestimentos.ListarPorId(id);
        }

        [HttpPost("salvar")]
        public NotificationResult Salvar(TodosInvestimentos todosInvestimentos)
        {
            return appTodosInvestimentos.Salvar(todosInvestimentos);
        }

        [HttpDelete("excluir")]
        public string Excluir(int id)
        {
            return appTodosInvestimentos.Excluir(id);
        }
    }
}
