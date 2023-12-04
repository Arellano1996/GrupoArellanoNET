﻿// <auto-generated />
using System;
using GrupoArellano.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrupoArellano.Persistence.Migrations
{
    [DbContext(typeof(GrupoArellanoDbContext))]
    [Migration("20231204224412_corregir_relaciones")]
    partial class corregir_relaciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistaCancion", b =>
                {
                    b.Property<Guid>("ArtistasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CancionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistasId", "CancionId");

                    b.HasIndex("CancionId");

                    b.ToTable("CancionArtista", (string)null);
                });

            modelBuilder.Entity("CancionGenero", b =>
                {
                    b.Property<Guid>("CancionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenerosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CancionId", "GenerosId");

                    b.HasIndex("GenerosId");

                    b.ToTable("CancionGenero", (string)null);
                });

            modelBuilder.Entity("CancionLinkCancion", b =>
                {
                    b.Property<Guid>("CancionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LinksCancionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CancionId", "LinksCancionId");

                    b.HasIndex("LinksCancionId");

                    b.ToTable("CancionLinkCancion", (string)null);
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Artista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Cancion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acordes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Letra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Canciones");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Genero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.LinkCancion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LinksCanciones");
                });

            modelBuilder.Entity("ArtistaCancion", b =>
                {
                    b.HasOne("GrupoArellano.Persistence.Entities.Artista", null)
                        .WithMany()
                        .HasForeignKey("ArtistasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoArellano.Persistence.Entities.Cancion", null)
                        .WithMany()
                        .HasForeignKey("CancionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CancionGenero", b =>
                {
                    b.HasOne("GrupoArellano.Persistence.Entities.Cancion", null)
                        .WithMany()
                        .HasForeignKey("CancionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoArellano.Persistence.Entities.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CancionLinkCancion", b =>
                {
                    b.HasOne("GrupoArellano.Persistence.Entities.Cancion", null)
                        .WithMany()
                        .HasForeignKey("CancionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoArellano.Persistence.Entities.LinkCancion", null)
                        .WithMany()
                        .HasForeignKey("LinksCancionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
