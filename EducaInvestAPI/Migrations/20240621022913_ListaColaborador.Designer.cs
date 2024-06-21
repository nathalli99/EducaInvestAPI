﻿// <auto-generated />
using System;
using EducaInvestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducaInvestAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240621022913_ListaColaborador")]
    partial class ListaColaborador
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducaInvestAPI.Entities.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CronogramaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInicioAtividade")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataTerminoAtividade")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoAtividade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Percentual")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("StatusAtividade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CronogramaId");

                    b.ToTable("TB_ATIVIDADES", (string)null);
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Cronograma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId")
                        .IsUnique();

                    b.ToTable("TB_CRONOGRAMAS", (string)null);
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CronogramaId")
                        .HasColumnType("int");

                    b.Property<decimal>("CustoProjeto")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoProjeto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FileBytes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Investido")
                        .HasColumnType("bit");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusProjeto")
                        .HasColumnType("int");

                    b.Property<string>("Subtitulo")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PROJETOS", (string)null);
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileBytes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkSocial")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "",
                            Cidade = "",
                            DataAcesso = new DateTime(2024, 6, 20, 23, 29, 13, 501, DateTimeKind.Local).AddTicks(2764),
                            Email = "educainvest.co@gmail.com",
                            LinkSocial = "",
                            Nome = "",
                            PasswordHash = new byte[] { 29, 40, 52, 4, 222, 153, 139, 233, 228, 238, 29, 152, 16, 25, 119, 156, 73, 170, 56, 241, 156, 110, 225, 234, 26, 17, 244, 40, 251, 19, 129, 210, 180, 40, 170, 253, 90, 48, 213, 109, 136, 166, 214, 83, 59, 113, 117, 251, 176, 193, 11, 0, 54, 215, 104, 114, 246, 165, 166, 250, 176, 87, 47, 243 },
                            PasswordSalt = new byte[] { 101, 250, 147, 93, 141, 220, 229, 249, 197, 168, 200, 82, 32, 130, 246, 110, 154, 247, 58, 139, 56, 223, 142, 125, 130, 36, 237, 165, 77, 236, 168, 102, 147, 15, 215, 139, 209, 20, 253, 92, 25, 28, 71, 38, 201, 65, 57, 145, 150, 60, 58, 53, 104, 240, 130, 7, 95, 230, 94, 20, 50, 165, 109, 185, 93, 253, 144, 64, 22, 42, 23, 35, 18, 21, 226, 32, 158, 169, 173, 230, 232, 52, 152, 90, 38, 98, 62, 89, 82, 52, 242, 141, 2, 97, 43, 38, 73, 254, 154, 32, 254, 192, 140, 175, 78, 20, 137, 213, 24, 78, 118, 192, 45, 112, 114, 94, 233, 81, 204, 3, 64, 51, 53, 167, 103, 178, 131, 196 },
                            Perfil = 1,
                            Sobrenome = "",
                            Telefone = "",
                            UF = 6
                        });
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Atividade", b =>
                {
                    b.HasOne("EducaInvestAPI.Entities.Cronograma", "Cronograma")
                        .WithMany("Atividades")
                        .HasForeignKey("CronogramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cronograma");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Cronograma", b =>
                {
                    b.HasOne("EducaInvestAPI.Entities.Projeto", "Projeto")
                        .WithOne("Cronograma")
                        .HasForeignKey("EducaInvestAPI.Entities.Cronograma", "ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Projeto", b =>
                {
                    b.HasOne("EducaInvestAPI.Entities.Usuario", "Usuario")
                        .WithMany("Projetos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Usuario", b =>
                {
                    b.HasOne("EducaInvestAPI.Entities.Projeto", null)
                        .WithMany("Colaboradores")
                        .HasForeignKey("ProjetoId");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Cronograma", b =>
                {
                    b.Navigation("Atividades");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Projeto", b =>
                {
                    b.Navigation("Colaboradores");

                    b.Navigation("Cronograma");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Usuario", b =>
                {
                    b.Navigation("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}