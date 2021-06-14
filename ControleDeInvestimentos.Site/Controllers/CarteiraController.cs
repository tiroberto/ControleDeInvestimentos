using Aplicacao;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeInvestimentos.Site.Controllers
{
    public class CarteiraController : Controller
    {
        CarteiraAplicacao appCarteira;

        public CarteiraController()
        {
            appCarteira = new CarteiraAplicacao();
        }

        // GET: CarteiraController
        public ActionResult Index()
        {
            var listaCarteiras = appCarteira.Listar();
            return View(listaCarteiras);
        }

        // GET: CarteiraController/Details/5
        public ActionResult Detalhes(int id)
        {
            var carteiraDetalhes = appCarteira.ListarPorId(id);
            if (carteiraDetalhes == null)
                return NotFound();
            return View(carteiraDetalhes);
        }

        // GET: CarteiraController/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: CarteiraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Carteira carteira)
        {
            try
            {
                appCarteira.Salvar(carteira);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Cadastrar");
            }
        }

        // GET: CarteiraController/Edit/5
        public ActionResult Editar(int id)
        {
            var carteiraEditar = appCarteira.ListarPorId(id);
            return View(carteiraEditar);
        }

        // POST: CarteiraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Carteira carteira)
        {
            try
            {
                appCarteira.Salvar(carteira);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Editar", carteira.CarteiraId);
            }
        }

        // GET: CarteiraController/Delete/5
        public ActionResult Excluir(int id)
        {
            var carteiraExcluir = appCarteira.ListarPorId(id);
            return View(carteiraExcluir);
        }

        // POST: CarteiraController/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            try
            {
                appCarteira.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Excluir", id);
            }
        }

        // GET
        public ActionResult AdicionarInvestimento(int id)
        {
            TodosInvestimentosAplicacao appTodosInvestimentos = new TodosInvestimentosAplicacao();

            var carteiraAddInvest = appCarteira.ListarPorId(id);
            ViewBag.listaInvestimentos = appTodosInvestimentos.Listar();

            return View(carteiraAddInvest);
        }

        // POST
        [HttpPost, ActionName("AdicionarInvestimento")]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarInvestimentoConfirmar(Investimento investimento)
        {
            InvestimentoAplicacao appInvestimento = new InvestimentoAplicacao();
            try
            {
                appInvestimento.Salvar(investimento);
                return RedirectToAction("Detalhes", investimento.Carteira.CarteiraId);
            }
            catch
            {
                return RedirectToAction("AdicionarCarteira", investimento.Carteira.CarteiraId);
            }
        }
    }
}
