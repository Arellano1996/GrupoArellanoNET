﻿// <auto-generated />
using System;
using GrupoArellano.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrupoArellano.Persistence.Migrations
{
    [DbContext(typeof(GrupoArellanoDbContext))]
    partial class GrupoArellanoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Artista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CancionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CancionId");

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

                    b.Property<Guid?>("CancionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CancionId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.LinkCancion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CancionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CancionId");

                    b.ToTable("LinksCanciones");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Artista", b =>
                {
                    b.HasOne("GrupoArellano.Persistence.Entities.Cancion", null)
                        .WithMany("Artistas")
                        .HasForeignKey("CancionId");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Genero", b =>
                {
                    b.HasOne("GrupoArellano.Persistence.Entities.Cancion", null)
                        .WithMany("Generos")
                        .HasForeignKey("CancionId");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.LinkCancion", b =>
                {
                    b.HasOne("GrupoArellano.Persistence.Entities.Cancion", null)
                        .WithMany("LinksCancion")
                        .HasForeignKey("CancionId");
                });

            modelBuilder.Entity("GrupoArellano.Persistence.Entities.Cancion", b =>
                {
                    b.Navigation("Artistas");

                    b.Navigation("Generos");

                    b.Navigation("LinksCancion");
                });
#pragma warning restore 612, 618
        }
    }
}
