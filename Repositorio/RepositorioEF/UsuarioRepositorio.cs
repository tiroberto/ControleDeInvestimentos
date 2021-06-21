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

        public async Task<IEnumerable<Usuario>> Listar()
        {
            return await _contexto.Usuario
                .Include(x => x.Enderecos)
                .Include(x => x.Carteiras)
                .ToListAsync();
        }

        public Usuario ListarPorId(int id)
        {
            return _contexto.Usuario
                .Include(x => x.Enderecos)
                .Include(x => x.Carteiras)
                .First(x => x.UsuarioId == id);
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _contexto.Usuario.Update(usuario);
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            Usuario usuarioExcluir = _contexto.Usuario
                .Include(x => x.Enderecos)
                .Include(x => x.Carteiras)
                .Where(x => x.UsuarioId == id)
                .First();
            _contexto.Carteiras.RemoveRange(_contexto.Carteiras.Where(x => x.Usuario.UsuarioId == id));
            _contexto.Endereco.RemoveRange(_contexto.Endereco.Where(x => x.Usuario.UsuarioId == id));
            _contexto.Usuario.Remove(usuarioExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
