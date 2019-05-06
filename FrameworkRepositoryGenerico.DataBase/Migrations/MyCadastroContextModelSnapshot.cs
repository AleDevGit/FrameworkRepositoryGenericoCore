﻿// <auto-generated />
using System;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrameworkRepositoryGenerico.DataBase.Migrations
{
    [DbContext(typeof(MyCadastroContext))]
    partial class MyCadastroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Ano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Ano");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cpf_Cnpj")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("TipoClienteId");

                    b.HasKey("Id");

                    b.HasIndex("TipoClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("TipoContatoId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("TipoContatoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Fabricante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Regra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Regra");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.TipoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("TipoCliente");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.TipoContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("TipoContato");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("TipoProduto");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.UsuarioRegra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RegraId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("RegraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioRegra");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Cliente", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.TipoCliente", "TipoCliente")
                        .WithMany()
                        .HasForeignKey("TipoClienteId");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Contato", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.TipoContato", "TipoContato")
                        .WithMany()
                        .HasForeignKey("TipoContatoId");

                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.Usuario", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Endereco", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.Usuario", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.Cliente", "Cliente")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.Entidades.UsuarioRegra", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.Regra", "Regra")
                        .WithMany("UsuarioRegras")
                        .HasForeignKey("RegraId");

                    b.HasOne("FrameworkRepositoryGenerico.DataBase.Entidades.Usuario", "Usuario")
                        .WithMany("UsuarioRegras")
                        .HasForeignKey("UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
