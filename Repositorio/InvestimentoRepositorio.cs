using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

        public void Salvar(Investimento investimento)
        {
            if (investimento.Id > 0)
            {
                Alterar(investimento);
            }
            else
            {
                Adicionar(investimento);
            }
        }

        public IEnumerable<Investimento> Listar()
        {
            return _contexto.Investimentos.Include(x => x.TipoInvestimento).ToList();
        }

        public Investimento ListarPorId(int id)
        {
            return _contexto.Investimentos.Find(id);
        }

        public void Adicionar(Investimento investimento)
        {
            investimento.TipoInvestimento = _contexto.TiposdeInvestimento.ToList().Where(x => x.Id == investimento.TipoInvestimento.Id).FirstOrDefault();
            _contexto.Investimentos.Add(investimento);
            _contexto.SaveChanges();
        }

        public void Alterar(Investimento investimento)
        {
            Investimento investimentoSalvar = _contexto.Investimentos.Where(x => x.Id == investimento.Id).First();
            investimentoSalvar.Nome = investimento.Nome;
            investimentoSalvar.Quantidade = investimento.Quantidade;
            investimentoSalvar.Valor = investimento.Valor;
            investimentoSalvar.ValorTotal = investimento.ValorTotal;
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Investimento investimentoExcluir = _contexto.Investimentos.First(x => x.Id == id);
            _contexto.Set<Investimento>().Remove(investimentoExcluir);
            _contexto.SaveChanges();
        }
    }
}
