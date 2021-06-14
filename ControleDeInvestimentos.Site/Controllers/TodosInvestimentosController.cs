using Aplicacao;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeInvestimentos.Site.Controllers
{
    public class TodosInvestimentosController : Controller
    {
        TodosInvestimentosAplicacao appTodosInvestimentos;

        public TodosInvestimentosController()
        {
            appTodosInvestimentos = new TodosInvestimentosAplicacao();
        }

        // GET
        public IActionResult Index()
        {
            var listaTodosInvestimentos = appTodosInvestimentos.Listar();
            return View(listaTodosInvestimentos);
        }

        // GET
        public IActionResult Detalhes(int id)
        {
            var todosInvestimentosDetalhes = appTodosInvestimentos.ListarPorId(id);
            if (todosInvestimentosDetalhes == null)
                return NotFound();
            return View(todosInvestimentosDetalhes);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(TodosInvestimentos todosInvestimentos)
        {
            try
            {
                appTodosInvestimentos.Salvar(todosInvestimentos);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Cadastrar");
            }
        }

        // GET
        public IActionResult Editar(int id)
        {
            var todosInvestimentosEditar = appTodosInvestimentos.ListarPorId(id);
            return View(todosInvestimentosEditar);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TodosInvestimentos todosInvestimentos)
        {
            try
            {
                appTodosInvestimentos.Salvar(todosInvestimentos);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Editar", todosInvestimentos.TodosInvestimentosId);
            }
        }

        // GET
        public IActionResult Excluir(int id)
        {
            var todosInvestimentosExcluir = appTodosInvestimentos.ListarPorId(id);
            return View(todosInvestimentosExcluir);
        }

        // POST
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmado(int id)
        {
            try
            {
                appTodosInvestimentos.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Excluir", id);
            }
        }
    }
}
