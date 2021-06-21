using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.RepositorioEF
{
    public class EnderecoRepositorio
    {
        private Contexto _contexto;

        public EnderecoRepositorio()
        {
            _contexto = new Contexto();
        }

        public async Task<IEnumerable<Endereco>> Listar()
        {
            return await _contexto.Endereco
                .Include(x=>x.Usuario)
                .ToListAsync();
        }

        public Endereco ListarPorId(int id)
        {
            return _contexto.Endereco
                .Include(x => x.Usuario)
                .First(x => x.EnderecoId == id);
        }

        public void Adicionar(Endereco endereco)
        {
            endereco.Usuario = _contexto.Usuario
                .ToList()
                .Where(x => x.UsuarioId == endereco.Usuario.UsuarioId)
                .FirstOrDefault();
            _contexto.Endereco.Add(endereco);
            _contexto.SaveChanges();
        }

        public void Alterar(Endereco endereco)
        {
            _contexto.Endereco.Update(endereco);
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            Endereco enderecoExcluir = _contexto.Endereco
                .First(x => x.EnderecoId == id);
            _contexto.Endereco.Remove(enderecoExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
