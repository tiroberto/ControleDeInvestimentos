using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Repositorio.Configuracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Contexto : DbContext
    {

        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<TipoInvestimento> TiposdeInvestimento { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }

        internal Usuario Include()
        {
            throw new NotImplementedException();
        }

        public DbSet<TodosInvestimentos> TodosInvestimentos { get; set; }
        public DbSet<UsuarioEndereco> UsuarioEndereco { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=localhost;Database=controledeinvestimentos;Uid=root;Pwd=418951230;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestimentoConfiguracao());
            modelBuilder.ApplyConfiguration(new CarteiraConfiguracao());
            modelBuilder.ApplyConfiguration(new TipoInvestimentoConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioEnderecoConfiguracao());
        }

    }
}
