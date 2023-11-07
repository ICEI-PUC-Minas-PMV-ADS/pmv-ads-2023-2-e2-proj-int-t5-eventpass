﻿// <auto-generated />
using System;
using EventPass1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventPass1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231107182210_M25")]
    partial class M25
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventPass1.Models.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvento"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GestorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalIngressos")
                        .HasColumnType("int");

                    b.HasKey("IdEvento");

                    b.HasIndex("GestorId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EventPass1.Models.Ingresso", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("IdEvento")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Ingressos");
                });

            modelBuilder.Entity("EventPass1.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmarSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("EventPass1.Models.Evento", b =>
                {
                    b.HasOne("EventPass1.Models.Usuario", "Usuario")
                        .WithMany("Eventos")
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EventPass1.Models.Ingresso", b =>
                {
                    b.HasOne("EventPass1.Models.Evento", "Evento")
                        .WithMany("Ingressos")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPass1.Models.Usuario", "Usuario")
                        .WithMany("Ingressos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EventPass1.Models.Evento", b =>
                {
                    b.Navigation("Ingressos");
                });

            modelBuilder.Entity("EventPass1.Models.Usuario", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("Ingressos");
                });
#pragma warning restore 612, 618
        }
    }
}
