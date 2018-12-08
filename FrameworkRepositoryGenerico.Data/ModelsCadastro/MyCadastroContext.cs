using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrameworkRepositoryGenerico.Data.ModelsCadastro
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=.;Database=Cadastro;user id=framework;password=framework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Bairro)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro).IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Endereco_Cliente");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.Property(e => e.Telefone1)
                    .HasColumnName("Telefone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Telefone)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Telefone_Cliente");

                entity.HasOne(d => d.IdTipoTelefoneNavigation)
                    .WithMany(p => p.Telefone)
                    .HasForeignKey(d => d.IdTipoTelefone)
                    .HasConstraintName("FK_Telefone_TipoTelefone");
            });

            modelBuilder.Entity<TipoTelefone>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
