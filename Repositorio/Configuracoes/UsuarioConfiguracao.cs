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
    class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "controledeinvestimentos");
            builder.HasKey("UsuarioId");
            builder.Property(i => i.Nome)
                .HasMaxLength(100)
                .HasColumnName("Nome");
            builder.Property(i => i.Email)
                .HasMaxLength(50)
                .HasColumnName("Email");
            builder.Property(i => i.Senha)
                .HasMaxLength(20)
                .HasColumnName("Senha");
            builder.HasMany(i => i.Enderecos)
                .WithOne(i => i.Usuario)
                .HasForeignKey("EnderecoId");
        }
    }
}
