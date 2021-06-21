using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TodosInvestimentos
    {
        public int TodosInvestimentosId { get; set; }
        public string Nome { get; set; }
        public string Ticket { get; set; }
        public IEnumerable<Investimento> Investimentos { get; set; }
        public TipoInvestimento TipoInvestimento { get; set; }
    }
}
