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
    public class CarteiraAplicacao
    {
        private readonly CarteiraRepositorio _repositorio;

        public CarteiraAplicacao()
        {
            _repositorio = new CarteiraRepositorio();
        }

        public int ListarQuantidadeInvestimentos(int id)
        {
            return _repositorio.ListarQuantidadeInvestimentos(id);
        }
        
        public NotificationResult Salvar(Carteira carteira)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    if (carteira.CarteiraId == 0)
                    {
                        _repositorio.Adicionar(carteira);
                        notificationResult.Add("Carteira cadastrado com sucesso.");
                    }
                    else
                    {
                        _repositorio.Alterar(carteira);
                        notificationResult.Add("Carteira atualizado com sucesso.");
                    }
                }

                notificationResult.Result = carteira;

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

        public async Task<IEnumerable<Carteira>> Listar()
        {
            return await _repositorio.Listar();
        }

        public Carteira ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }

        public NotificationResult AdicionarInvestimento(Investimento investimento)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    _repositorio.AdicionarInvestimento(investimento);
                }

                notificationResult.Result = investimento;

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}
