using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class InvestimentoCarteira
    {
        public int InvestimentoId { get; set; }
        public Investimento Investimento { get; set; }
        public int CarteiraId { get; set; }
        public Carteira Carteira { get; set; }
    }
}
