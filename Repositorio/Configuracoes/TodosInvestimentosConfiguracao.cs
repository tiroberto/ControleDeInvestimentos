using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Configuracoes
{
    public class TodosInvestimentosConfiguracao : IEntityTypeConfiguration<TodosInvestimentos>
    {
        public void Configure(EntityTypeBuilder<TodosInvestimentos> builder)
        {
            builder.ToTable("todosinvestimentos", "controledeinvestimentos");
            builder.HasKey("TodosInvestimentosId");
            builder.Property(ti => ti.Nome);
            builder.Property(ti => ti.Ticket);
            builder.HasOne(ti => ti.TipoInvestimento)
                .WithMany(ti => ti.Investimentos)
                .HasForeignKey("TipoInvestimentoId");
            builder.HasMany(ti => ti.Investimentos)
                .WithOne(ti => ti.InvestimentoSelecionado);
            //builder.HasOne(i => i.InvestimentoUnico)
            //    .WithOne(c => c.InvestimentoUnico)
            //    .HasForeignKey<Investimento>(p => p.InvestimentoId);
        }
    }
}
