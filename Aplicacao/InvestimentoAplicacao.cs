using Aplicacao.NotificationPattern;
using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class InvestimentoAplicacao
    {
        private readonly InvestimentoRepositorio _repositorio;

        public InvestimentoAplicacao()
        {
            _repositorio = new InvestimentoRepositorio();
        }

        public NotificationResult Salvar(Investimento investimento)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    if (investimento.InvestimentoId == 0)
                    {
                        _repositorio.Adicionar(investimento);
                        notificationResult.Add("Investimento cadastrado com sucesso.");
                    }
                    else
                    {
                        _repositorio.Alterar(investimento);
                        notificationResult.Add("Investimento atualizado com sucesso.");
                    }
                }

                notificationResult.Result = investimento;

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

        public async Task<IEnumerable<Investimento>> Listar()
        {
            return await _repositorio.Listar();
        }

        public Investimento ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
