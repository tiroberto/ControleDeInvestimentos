using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repositorio
{
    public class TipoInvestimentoRepositorio
    {
        private Contexto _contexto;

        public TipoInvestimentoRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Salvar(TipoInvestimento tipoinvestimento)
        {
            if(tipoinvestimento.TipoInvestimentoId > 0)
            {
                Alterar(tipoinvestimento);
            }
            else
            {
                Adicionar(tipoinvestimento);
            }
        }

        public IEnumerable<TipoInvestimento> Listar()
        {
            return _contexto.TiposdeInvestimento.ToList();
        }

        public TipoInvestimento ListarPorId(int id)
        {
            return _contexto.TiposdeInvestimento.Find(id);
        }

        public void Adicionar(TipoInvestimento tipoInvestimento)
        {
            _contexto.TiposdeInvestimento.Add(tipoInvestimento);
            _contexto.SaveChanges();
        }

        public void Alterar(TipoInvestimento tipoInvestimento)
        {
            TipoInvestimento tipoInvestimentoAlterar = _contexto.TiposdeInvestimento.Where(x => x.TipoInvestimentoId == tipoInvestimento.TipoInvestimentoId).First();
            tipoInvestimentoAlterar.Nome = tipoInvestimento.Nome;
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            TipoInvestimento tipoInvestimentoExcluir = _contexto.TiposdeInvestimento.First(x => x.TipoInvestimentoId == id);
            _contexto.Set<TipoInvestimento>().Remove(tipoInvestimentoExcluir);
            _contexto.SaveChanges();
        }
    }
}
