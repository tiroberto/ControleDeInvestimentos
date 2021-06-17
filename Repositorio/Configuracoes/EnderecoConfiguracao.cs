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
    public class EnderecoConfiguracao : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco", "controledeinvestimentos");
            builder.HasKey("EnderecoId");
            builder.Property(e => e.Logradouro)
                .HasMaxLength(70)
                .HasColumnName("Nome");
            builder.Property(e => e.Numero)
                .HasColumnName("Numero");
            builder.Property(e => e.Bairro)
                .HasMaxLength(70)
                .HasColumnName("Bairro");
            builder.Property(e => e.CEP)
                .HasMaxLength(10)
                .HasColumnName("CEP");
            builder.Property(e => e.Cidade)
                .HasMaxLength(70)
                .HasColumnName("Cidade");
            builder.Property(e => e.UFEstado)
                .HasMaxLength(2)
                .HasColumnName("UFEstado");
            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.Enderecos);
        }
    }
}
