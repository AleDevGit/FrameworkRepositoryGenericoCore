using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
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
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<TipoContato> TipoContato { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<Regra> Regra { get; set; }
        public virtual DbSet<UsuarioRegra> UsuarioRegra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(p => p.Id);
            modelBuilder.Entity<Endereco>().HasKey(p => p.Id);
            modelBuilder.Entity<Contato>().HasKey(p => p.Id);
            modelBuilder.Entity<TipoContato>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);



            base.OnModelCreating(modelBuilder);
        }
    }
}
