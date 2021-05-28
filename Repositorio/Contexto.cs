using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Contexto:DbContext
    {
        public Contexto():base("ControleDeInvestimentos")
        {

        }
        
        public DbSet<Investimento> Investimentos { get; set; }

        public DbSet<TipoInvestimento> TiposdeInvestimento { get; set; }

        public DbSet<Carteira> Carteiras { get; set; }
    }
}
