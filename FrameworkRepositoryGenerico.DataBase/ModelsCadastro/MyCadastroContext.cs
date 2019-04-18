using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrameworkRepositoryGenerico.DataBase.ModelsCadastro
{
    public partial class MyCadastroContext : DbContext
    {
        public MyCadastroContext()
        {
        }

        public MyCadastroContext(DbContextOptions<MyCadastroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<TipoTelefone> TipoTelefone { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(p => p.Id);
            modelBuilder.Entity<Endereco>().HasKey(p => p.Id);
            modelBuilder.Entity<Telefone>().HasKey(p => p.Id);
            modelBuilder.Entity<TipoTelefone>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
