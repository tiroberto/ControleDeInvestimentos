using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoInvestimento
    {
        public int TipoInvestimentoId { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<TodosInvestimentos> Investimentos { get; set; }
    }
}
