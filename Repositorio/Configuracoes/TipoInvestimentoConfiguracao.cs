using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio.Configuracoes
{
    class TipoInvestimentoConfiguracao : IEntityTypeConfiguration<TipoInvestimento>
    {
        public void Configure(EntityTypeBuilder<TipoInvestimento> builder)
        {
            builder.ToTable("tipoinvestimento", "controledeinvestimentos");
            builder.HasKey("TipoInvestimentoId");
            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Nome");
        }
    }
}
