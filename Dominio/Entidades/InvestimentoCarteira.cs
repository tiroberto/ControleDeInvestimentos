using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class InvestimentoCarteira
    {
        [Key]
        [ForeignKey("InvestimentoId")]
        public int InvestimentoId { get; set; }
        public Investimento Investimento { get; set; }

        [Key]
        [ForeignKey("CarteiraId")]
        public int CarteiraId { get; set; }
        public Carteira Carteira { get; set; }
    }
}
