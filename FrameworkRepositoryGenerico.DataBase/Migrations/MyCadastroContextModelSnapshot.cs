﻿// <auto-generated />
using System;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
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
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<string>("Rg");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Municipio");

                    b.Property<string>("Uf");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Numero");

                    b.Property<int?>("TipoTelefoneId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoTelefoneId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("TipoTelefone");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Endereco", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Cliente", "Cliente")
                        .WithMany("Endereco")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Telefone", b =>
                {
                    b.HasOne("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.Cliente", "Cliente")
                        .WithMany("Telefone")
                        .HasForeignKey("ClienteId");

                    b.HasOne("FrameworkRepositoryGenerico.DataBase.ModelsCadastro.TipoTelefone", "TipoTelefone")
                        .WithMany()
                        .HasForeignKey("TipoTelefoneId");
                });
#pragma warning restore 612, 618
        }
    }
}
