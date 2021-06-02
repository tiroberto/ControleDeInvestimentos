using Aplicacao;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeInvestimentos.Site.Controllers
{
    public class InvestimentoController : Controller
    {
        private readonly InvestimentoAplicacao appInvestimento;

        public InvestimentoController()
        {
            appInvestimento = new InvestimentoAplicacao();
        }

        public IActionResult Index()
        {
            var listaInvestimentos = appInvestimento.Listar();
            return View(listaInvestimentos);
        }

        public IActionResult Cadastrar()
        {
            TipoInvestimentoAplicacao appTipoInvestimento = new TipoInvestimentoAplicacao();
            /*ViewBag.listaTipoInvestimento = new SelectList
                (
                    appTipoInvestimento.Listar(),
                    "TipoInvestimentoId",
                    "Nome"
                );*/
            ViewBag.listaTipoInvestimento = appTipoInvestimento.Listar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                appInvestimento.Salvar(investimento);
                return RedirectToAction("Index");
            }            
            //TipoInvestimentoAplicacao appTipoInvestimento = new TipoInvestimentoAplicacao();
            return View(investimento);
        }

        public IActionResult Editar(int id)
        {
            var investimentoDetalhes = appInvestimento.ListarPorId(id);
            if (investimentoDetalhes == null)
                return NotFound();
            return View(investimentoDetalhes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                appInvestimento.Salvar(investimento);
                return RedirectToAction("Index");
            }
            return View(investimento);
        }

        public IActionResult Detalhes(int id)
        {
            var investimentoDetalhes = appInvestimento.ListarPorId(id);
            if (investimentoDetalhes == null)
                return NotFound();
            return View(investimentoDetalhes);
        }

        public IActionResult Excluir(int id)
        {
            var investimentoDetalhes = appInvestimento.ListarPorId(id);
            if (investimentoDetalhes == null)
                return NotFound();
            return View(investimentoDetalhes);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmado(int id)
        {
            appInvestimento.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
