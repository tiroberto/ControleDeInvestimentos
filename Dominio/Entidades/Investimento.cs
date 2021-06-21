using Dominio.Entidades;
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
        public decimal ValorTotal { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal Quantidade { get; set; }
        public TodosInvestimentos InvestimentoSelecionado { get; set; }
        public Carteira Carteira { get; set; }
    }
}
