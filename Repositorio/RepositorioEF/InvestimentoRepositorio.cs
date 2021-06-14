using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class InvestimentoRepositorio
    {
        private Contexto _contexto;

        public InvestimentoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Investimento> Listar()
        {
            return _contexto.Investimentos
                .Include(x => x.InvestimentoUnico.TipoInvestimento)
                .Include(c => c.Carteira)
                .ToList();
        }

        public Investimento ListarPorId(int id)
        {
            return _contexto.Investimentos
                .Include(x => x.InvestimentoUnico.TipoInvestimento)
                .Include(c => c.Carteira)
                .First(x => x.InvestimentoId == id);
        }

        public void Adicionar(Investimento investimento)
        {
            investimento.InvestimentoUnico = _contexto.TodosInvestimentos.ToList().Where(x => x.TodosInvestimentosId == investimento.InvestimentoUnico.TodosInvestimentosId).FirstOrDefault();
            investimento.Carteira = _contexto.Carteiras.ToList().Where(x => x.CarteiraId == investimento.Carteira.CarteiraId).FirstOrDefault();
            _contexto.Investimentos.Add(investimento);
            _contexto.SaveChanges();
        }

        public void Alterar(Investimento investimento)
        {
            _contexto.Update(investimento);
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            Investimento investimentoExcluir = _contexto.Investimentos.First(x => x.InvestimentoId == id);
            _contexto.Investimentos.Remove(investimentoExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
