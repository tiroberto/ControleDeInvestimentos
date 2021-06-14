using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Entidades;

namespace Repositorio.Configuracoes
{
    class InvestimentoConfiguracao : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.ToTable("investimento", "controledeinvestimentos");
            builder.HasKey("InvestimentoId");
            builder.Property(i => i.PrecoMedio)
                .HasColumnName("PrecoMedio");
            builder.Property(i => i.Quantidade)
                .HasColumnName("Quantidade");
            builder.Property(i => i.ValorTotal)
                .HasColumnName("ValorTotal");
            builder.HasOne(t => t.InvestimentoUnico)
                .WithOne(i => i.InvestimentoUnico)
                .HasForeignKey<TodosInvestimentos>(ti => ti.TodosInvestimentosId);
            builder.HasOne(c => c.Carteira)
                .WithMany(i => i.Investimentos);
        }
    }
}
