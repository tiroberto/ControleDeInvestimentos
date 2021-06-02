using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Investimento
    {
        public int InvestimentoId { get; set; }
        public string Nome { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal Quantidade { get; set; }
        public TipoInvestimento TipoInvestimento { get; set; }
        public IEnumerable<InvestimentoCarteira> InvestimentoCarteiras { get; set; }
    }
}
