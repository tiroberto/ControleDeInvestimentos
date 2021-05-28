using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoInvestimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual IEnumerable<Investimento> Investimentos { get; set; }
    }
}
