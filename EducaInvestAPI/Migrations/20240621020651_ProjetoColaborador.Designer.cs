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
    [Migration("20240621020651_ProjetoColaborador")]
    partial class ProjetoColaborador
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

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "",
                            Cidade = "",
                            DataAcesso = new DateTime(2024, 6, 20, 23, 6, 50, 677, DateTimeKind.Local).AddTicks(4358),
                            Email = "educainvest.co@gmail.com",
                            LinkSocial = "",
                            Nome = "",
                            PasswordHash = new byte[] { 1, 130, 113, 126, 210, 206, 196, 151, 35, 248, 28, 73, 169, 209, 59, 38, 184, 152, 46, 80, 212, 188, 155, 120, 185, 189, 251, 139, 52, 184, 207, 169, 47, 182, 162, 171, 49, 172, 124, 252, 215, 151, 205, 59, 18, 49, 15, 72, 29, 135, 139, 95, 61, 18, 4, 27, 114, 104, 94, 168, 191, 113, 202, 65 },
                            PasswordSalt = new byte[] { 132, 23, 63, 15, 237, 93, 92, 128, 137, 232, 173, 206, 227, 86, 42, 209, 251, 120, 101, 168, 45, 16, 113, 217, 102, 153, 91, 18, 93, 75, 234, 31, 83, 234, 86, 57, 228, 34, 12, 56, 17, 25, 85, 9, 173, 40, 245, 223, 175, 157, 185, 172, 38, 113, 243, 235, 18, 190, 142, 42, 242, 54, 95, 236, 81, 69, 44, 67, 217, 81, 221, 187, 3, 86, 49, 234, 25, 43, 101, 34, 131, 20, 241, 8, 66, 98, 86, 56, 28, 211, 201, 183, 189, 209, 178, 133, 221, 252, 105, 121, 216, 28, 177, 116, 1, 3, 40, 2, 234, 224, 75, 148, 190, 43, 252, 33, 62, 222, 244, 192, 98, 155, 12, 67, 145, 120, 46, 38 },
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

            modelBuilder.Entity("EducaInvestAPI.Entities.Cronograma", b =>
                {
                    b.Navigation("Atividades");
                });

            modelBuilder.Entity("EducaInvestAPI.Entities.Projeto", b =>
                {
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
