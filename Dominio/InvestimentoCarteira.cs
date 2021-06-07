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
        [ForeignKey(nameof(Investimento))]
        public int InvestimentoId { get; set; }
        public Investimento Investimento { get; set; }

        [Key]
        [ForeignKey(nameof(Carteira))]
        public int CarteiraId { get; set; }
        public Carteira Carteira { get; set; }
    }
}
