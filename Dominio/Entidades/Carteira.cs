using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carteira
    {
        public int CarteiraId { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Investimento> Investimentos { get; set; }
    }
}
