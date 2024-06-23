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
    [Migration("20240623070131_Login")]
    partial class Login
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

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "",
                            Cidade = "",
                            DataAcesso = new DateTime(2024, 6, 23, 4, 1, 31, 579, DateTimeKind.Local).AddTicks(6852),
                            Email = "educainvest.co@gmail.com",
                            LinkSocial = "",
                            Nome = "",
                            PasswordHash = new byte[] { 153, 182, 52, 35, 152, 194, 158, 229, 176, 141, 2, 223, 100, 11, 113, 163, 160, 253, 161, 251, 225, 166, 172, 246, 150, 233, 183, 129, 119, 118, 130, 180, 221, 141, 137, 173, 139, 214, 164, 143, 170, 124, 66, 121, 180, 177, 31, 152, 219, 38, 97, 236, 237, 172, 128, 207, 196, 233, 222, 32, 220, 55, 238, 243 },
                            PasswordSalt = new byte[] { 101, 239, 145, 122, 210, 96, 77, 210, 3, 167, 216, 76, 139, 134, 238, 128, 223, 53, 30, 245, 18, 196, 217, 178, 169, 77, 121, 1, 158, 154, 136, 236, 243, 208, 183, 189, 237, 85, 24, 8, 176, 134, 182, 216, 228, 196, 204, 4, 198, 57, 195, 198, 12, 54, 228, 107, 148, 28, 115, 59, 189, 199, 24, 14, 165, 108, 52, 185, 222, 104, 190, 139, 102, 172, 138, 108, 150, 221, 112, 230, 72, 186, 16, 190, 246, 24, 107, 22, 42, 10, 34, 197, 188, 128, 49, 14, 149, 144, 117, 100, 177, 59, 231, 126, 146, 139, 30, 217, 95, 207, 169, 123, 222, 29, 30, 90, 100, 223, 122, 195, 168, 103, 40, 57, 94, 91, 100, 94 },
                            Perfil = 1,
                            Sobrenome = "",
                            Telefone = "",
                            UF = ""
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