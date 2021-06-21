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

        public async Task<IEnumerable<TipoInvestimento>> Listar()
        {
            return await _contexto.TiposdeInvestimento
                .ToListAsync();
        }

        public TipoInvestimento ListarPorId(int id)
        {
            return _contexto.TiposdeInvestimento.First(x => x.TipoInvestimentoId == id);
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

        public string Excluir(int id)
        {
            TipoInvestimento tipoInvestimentoExcluir = _contexto.TiposdeInvestimento.First(x => x.TipoInvestimentoId == id);
            _contexto.TodosInvestimentos.RemoveRange(_contexto.TodosInvestimentos.Where(x => x.TipoInvestimento.TipoInvestimentoId == id));
            _contexto.TiposdeInvestimento.Remove(tipoInvestimentoExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
