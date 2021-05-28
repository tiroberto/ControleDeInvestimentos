using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Investimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public TipoInvestimento TipoInvestimento { get; set; }

        public virtual ICollection<Carteira> Carteira { get; set; }
    }
}
