using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carteira
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Investimento> Investimentos { get; set; }
    }
}
