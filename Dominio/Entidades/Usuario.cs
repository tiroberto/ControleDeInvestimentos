using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public IEnumerable<Carteira> Carteiras { get; set; }
    }
}
