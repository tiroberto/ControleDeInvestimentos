using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Configuracoes
{
    public class CarteiraConfiguracao : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.ToTable("carteira", "controledeinvestimentos");
            builder.HasKey("CarteiraId");
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Nome");
        }
    }
}
