using Aplicacao.NotificationPattern;
using Dominio.Entidades;
using Repositorio.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly UsuarioRepositorio _repositorio;

        public UsuarioAplicacao()
        {
            _repositorio = new UsuarioRepositorio();
        }

        public NotificationResult Salvar(Usuario usuario)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {
                    if (usuario.UsuarioId == 0)
                    {
                        _repositorio.Adicionar(usuario);
                        notificationResult.Add("Usuário cadastrado com sucesso.");
                    }
                    else
                    {
                        _repositorio.Alterar(usuario);
                        notificationResult.Add("Usuário atualizado com sucesso.");
                    }
                }

                notificationResult.Result = usuario;

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

        public IEnumerable<Usuario> Listar()
        {
            return _repositorio.Listar();
        }

        public Usuario ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
