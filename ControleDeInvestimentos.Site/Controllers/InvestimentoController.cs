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
        
        // GET
        public IActionResult Index()
        {
            var listaInvestimentos = appInvestimento.Listar();
            return View(listaInvestimentos);
        }
        
        public IActionResult Cadastrar()
        {
            TodosInvestimentosAplicacao appTodosInvestimentos = new TodosInvestimentosAplicacao();
            ViewBag.listaInvestimentos = appTodosInvestimentos.Listar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Investimento investimento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appInvestimento.Salvar(investimento);
                    return RedirectToAction("Index");
                }
                //TipoInvestimentoAplicacao appTipoInvestimento = new TipoInvestimentoAplicacao();
                return View(investimento);
            }
            catch
            {                
                return RedirectToAction("Cadastrar");
            }
            
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
            try
            {
                if (ModelState.IsValid)
                {
                    appInvestimento.Salvar(investimento);
                    return RedirectToAction("Index");
                }
                return View(investimento);
            }
            catch
            {
                return RedirectToAction("Editar",investimento.InvestimentoId);
            }            
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
            var investimentoExcluir = appInvestimento.ListarPorId(id);
            if (investimentoExcluir == null)
                return NotFound();
            return View(investimentoExcluir);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmado(int id)
        {
            try
            {
                appInvestimento.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Excluir",id);
            }            
        }

        //// GET
        //public ActionResult AdicionarInvestimento(string CarteiraId)
        //{
        //    TodosInvestimentosAplicacao appTodosInvestimentos = new TodosInvestimentosAplicacao();
        //    CarteiraAplicacao appCarteira = new CarteiraAplicacao();            

        //    var Carteira = appCarteira.ListarPorId(Convert.ToInt32(CarteiraId));
        //    ViewBag.listaInvestimentos = appTodosInvestimentos.Listar();

        //    return View();
        //}

        //// POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AdicionarInvestimentoConfirmar(int CarteiraId, int TodosInvestimentosId)
        //{
        //    //int investimentoId = Convert.ToInt32(InvestimentoId);
        //    //int carteiraId = Convert.ToInt32(CarteiraId);

        //    try
        //    {
        //        CarteiraAplicacao appCarteira = new CarteiraAplicacao();
        //        appCarteira.AdicionarInvestimento(TodosInvestimentosId, CarteiraId);
        //        return RedirectToAction("Detalhes", CarteiraId);
        //    }
        //    catch
        //    {
        //        return RedirectToAction("AdicionarCarteira", CarteiraId);
        //    }
        //}
    }
}
