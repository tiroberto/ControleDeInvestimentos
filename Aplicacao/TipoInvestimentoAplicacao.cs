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
    public class TipoInvestimentoAplicacao
    {
        private readonly TipoInvestimentoRepositorio _repositorio;

        public TipoInvestimentoAplicacao()
        {
            _repositorio = new TipoInvestimentoRepositorio();
        }

        public NotificationResult Salvar(TipoInvestimento tipoInvestimento)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    if (tipoInvestimento.TipoInvestimentoId == 0)
                    {
                        _repositorio.Adicionar(tipoInvestimento);
                        notificationResult.Add("Investimento cadastrado com sucesso.");
                    }
                    else
                    {
                        _repositorio.Alterar(tipoInvestimento);
                        notificationResult.Add("Investimento atualizado com sucesso.");
                    }
                }

                notificationResult.Result = tipoInvestimento;

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

        public async Task<IEnumerable<TipoInvestimento>> Listar()
        {
            return await _repositorio.Listar();
        }

        public TipoInvestimento ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
