using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.RepositorioEF
{
    public class UsuarioRepositorio
    {
        private Contexto _contexto;

        public UsuarioRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Usuario> Listar()
        {
            return _contexto.Usuario
                .Include(x => x.Enderecos)
                .ToList();
        }

        public Usuario ListarPorId(int id)
        {
            return _contexto.Usuario
                .Include(x => x.Enderecos)
                .First(x => x.UsuarioId == id);
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            Usuario usuarioAlterar = _contexto.Usuario
                .Include(x => x.Enderecos)
                .Where(x=>x.UsuarioId == usuario.UsuarioId)
                .First();
            _contexto.Usuario.Update(usuarioAlterar);
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            Usuario usuarioExcluir = _contexto.Usuario
                .Include(x => x.Enderecos)
                .Where(x => x.UsuarioId == id)
                .First();
            _contexto.Usuario.Remove(usuarioExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
