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
    public class EnderecoAplicacao
    {
        private readonly EnderecoRepositorio _repositorio;

        public EnderecoAplicacao()
        {
            _repositorio = new EnderecoRepositorio();
        }

        public NotificationResult Salvar(Endereco endereco)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    if (endereco.EnderecoId == 0)
                    {
                        _repositorio.Adicionar(endereco);
                        notificationResult.Add("Endereço cadastrado com sucesso.");
                    }
                    else
                    {
                        _repositorio.Alterar(endereco);
                        notificationResult.Add("Endereço atualizado com sucesso.");
                    }
                }

                notificationResult.Result = endereco;

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

        public IEnumerable<Endereco> Listar()
        {
            return _repositorio.Listar();
        }

        public Endereco ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
