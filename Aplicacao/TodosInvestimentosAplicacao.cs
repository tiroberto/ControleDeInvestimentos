using Aplicacao.NotificationPattern;
using Dominio;
using Dominio.Entidades;
using Repositorio.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class TodosInvestimentosAplicacao
    {
        private readonly TodosInvestimentosRepositorio _repositorio;

        public TodosInvestimentosAplicacao()
        {
            _repositorio = new TodosInvestimentosRepositorio();
        }

        public NotificationResult Salvar(TodosInvestimentos todosInvestimentos)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    if (todosInvestimentos.TodosInvestimentosId == 0)
                    {
                        _repositorio.Adicionar(todosInvestimentos);
                        notificationResult.Add("Investimento cadastrado com sucesso.");
                    }
                    else
                    {
                        _repositorio.Alterar(todosInvestimentos);
                        notificationResult.Add("Investimento atualizado com sucesso.");
                    }
                }
                notificationResult.Result = todosInvestimentos;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public string Excluir(int id)
        {
            return _repositorio.Excluir(id);
        }

        public async Task<IEnumerable<TodosInvestimentos>> Listar()
        {
            return await _repositorio.Listar();
        }

        public TodosInvestimentos ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        } 
    }
}
