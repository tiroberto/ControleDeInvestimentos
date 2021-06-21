using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.RepositorioEF
{
    public class TodosInvestimentosRepositorio
    {
        private Contexto _contexto;

        public TodosInvestimentosRepositorio()
        {
            _contexto = new Contexto();
        }

        public async Task<IEnumerable<TodosInvestimentos>> Listar()
        {
            return await _contexto.TodosInvestimentos
                .Include(x => x.Investimentos)
                .Include(c => c.TipoInvestimento)
                .ToListAsync();
        }

        public TodosInvestimentos ListarPorId(int id)
        {
            return _contexto.TodosInvestimentos
                .Include(j => j.Investimentos)
                .Include(c => c.TipoInvestimento)
                .First(x => x.TodosInvestimentosId == id);
        }

        public void Adicionar(TodosInvestimentos todosInvestimentos)
        {
            todosInvestimentos.TipoInvestimento = _contexto.TiposdeInvestimento
                .ToList()
                .Where(x => x.TipoInvestimentoId == todosInvestimentos.TipoInvestimento.TipoInvestimentoId)
                .FirstOrDefault();
            _contexto.TodosInvestimentos.Add(todosInvestimentos);
            _contexto.SaveChanges();
        }

        public void Alterar(TodosInvestimentos todosInvestimentos)
        {
            todosInvestimentos.TipoInvestimento = _contexto.TiposdeInvestimento
                .ToList()
                .Where(x => x.TipoInvestimentoId == todosInvestimentos.TipoInvestimento.TipoInvestimentoId)
                .FirstOrDefault();
            _contexto.Update(todosInvestimentos);
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            TodosInvestimentos todosInvestimentosExcluir = _contexto.TodosInvestimentos.First(x => x.TodosInvestimentosId == id);
            _contexto.Investimentos.RemoveRange(_contexto.Investimentos.Where(x => x.InvestimentoSelecionado.TodosInvestimentosId == id));
            _contexto.TodosInvestimentos.Remove(todosInvestimentosExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
