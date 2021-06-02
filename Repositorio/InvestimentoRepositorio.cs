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

        public void Salvar(Investimento investimento)
        {
            if (investimento.InvestimentoId > 0)
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
            return _contexto.Investimentos
                .Include(x => x.TipoInvestimento)
                //.Include(x=>x.InvestimentoCarteiras.Select(c=>c.Carteira))
                .ToList();
        }

        public Investimento ListarPorId(int id)
        {
            return _contexto.Investimentos
                .Include(c=>c.TipoInvestimento)
                .First(x=>x.InvestimentoId == id);
        }

        public void Adicionar(Investimento investimento)
        {
            investimento.TipoInvestimento = _contexto.TiposdeInvestimento.ToList().Where(x => x.TipoInvestimentoId == investimento.TipoInvestimento.TipoInvestimentoId).FirstOrDefault();
            _contexto.Investimentos.Add(investimento);
            _contexto.SaveChanges();
        }

        public void Alterar(Investimento investimento)
        {
            investimento.TipoInvestimento = _contexto.TiposdeInvestimento.ToList().Where(x => x.TipoInvestimentoId == investimento.TipoInvestimento.TipoInvestimentoId).FirstOrDefault();
            _contexto.Update(investimento);
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Investimento investimentoExcluir = _contexto.Investimentos.First(x => x.InvestimentoId == id);
            _contexto.Remove(investimentoExcluir);
            _contexto.SaveChanges();
        }
    }
}
