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
        public virtual IEnumerable<InvestimentoCarteira> InvestimentoCarteiras { get; set; }
    }
}
