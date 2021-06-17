using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class CarteiraRepositorio
    {
        public Contexto _contexto;

        public CarteiraRepositorio()
        {
            _contexto = new Contexto();
        }

        public int ListarQuantidadeInvestimentos(int id)
        {
            var carteira = _contexto.Carteiras
                .Include(ic => ic.Investimentos)
                .ThenInclude(c => c.InvestimentoUnico.TipoInvestimento)
                .First(x => x.CarteiraId == id);
            return carteira.Investimentos.ToList().Count();
        }

        public IEnumerable<Carteira> Listar()
        {
            //return    View(_context.Courses
            //          .Include(c => c.CourseLecturers)
            //          .ThenInclude(cl => cl.Lecturers)); 
            return _contexto.Carteiras
                .Include(i => i.Investimentos)
                .ThenInclude(c => c.InvestimentoUnico.TipoInvestimento)
                .ToList();
        }

        public Carteira ListarPorId(int id)
        {
            return _contexto.Carteiras
                .Include(ic => ic.Investimentos)
                .ThenInclude(c => c.InvestimentoUnico.TipoInvestimento)
                .First(x => x.CarteiraId == id);
        }

        public void AdicionarInvestimento(Investimento investimento)
        {
            _contexto.Set<Investimento>().Add(investimento);
            _contexto.SaveChanges();
        }

        public void Adicionar(Carteira carteira)
        {
            //carteira.Investimentos = carteira.Investimentos.Select(investimento => _contexto.Investimentos.FirstOrDefault(x => x.InvestimentoId == investimento.InvestimentoId)).ToList();
            _contexto.Carteiras.Add(carteira);
            _contexto.SaveChanges();
        }

        public void Alterar(Carteira carteira)
        {
            Carteira carteiraSalvar = _contexto.Carteiras.Where(x => x.CarteiraId == carteira.CarteiraId).First();
            //carteiraSalvar.Investimentos = carteira.Investimentos.Select(investimento => _contexto.Investimentos.FirstOrDefault(x => x.InvestimentoId == investimento.InvestimentoId)).ToList();
            carteiraSalvar.Nome = carteira.Nome;
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            Carteira carteiraExcluir = _contexto.Carteiras.Where(x => x.CarteiraId == id).First();
            //carteiraExcluir.Investimentos = null;
            _contexto.Carteiras.Remove(carteiraExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
