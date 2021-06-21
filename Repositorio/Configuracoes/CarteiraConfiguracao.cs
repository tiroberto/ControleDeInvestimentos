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
            builder.HasMany(c => c.Investimentos)
                .WithOne(c => c.Carteira);
            builder.HasOne(c => c.Usuario)
                .WithMany(c => c.Carteiras)
                .HasForeignKey("UsuarioId");
        }
    }
}
