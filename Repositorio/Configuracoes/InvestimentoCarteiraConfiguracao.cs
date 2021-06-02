﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;
using System.Threading.Tasks;

namespace Repositorio.Configuracoes
{
    class InvestimentoCarteiraConfiguracao : IEntityTypeConfiguration<InvestimentoCarteira>
    {
        public void Configure(EntityTypeBuilder<InvestimentoCarteira> builder)
        {
            builder.ToTable("investimento_carteira", "controledeinvestimentos");
            builder.HasKey(ic => new { ic.InvestimentoId, ic.CarteiraId });
        }
    }
}