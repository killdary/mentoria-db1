﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante.Infra.Writting.Data;

namespace Restaurante.Infra.Writting.Data.Migrations
{
    [DbContext(typeof(WritingContext))]
    partial class WritingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurante.Domain.Entities.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IngredienteCategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteCategoriaId");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.IngredienteCategoria", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("IngredienteCategorias");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.Passo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReceitaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReceitaId");

                    b.ToTable("Passo");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.Porcao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IngredienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<Guid?>("ReceitaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Unidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("Porcao");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.Receita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.Ingrediente", b =>
                {
                    b.HasOne("Restaurante.Domain.Entities.IngredienteCategoria", "IngredienteCategoria")
                        .WithMany("Ingredientes")
                        .HasForeignKey("IngredienteCategoriaId");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.Passo", b =>
                {
                    b.HasOne("Restaurante.Domain.Entities.Receita", "Receita")
                        .WithMany("Passos")
                        .HasForeignKey("ReceitaId");
                });

            modelBuilder.Entity("Restaurante.Domain.Entities.Porcao", b =>
                {
                    b.HasOne("Restaurante.Domain.Entities.Ingrediente", "Ingrediente")
                        .WithMany("Porcoes")
                        .HasForeignKey("IngredienteId");

                    b.HasOne("Restaurante.Domain.Entities.Receita", "Receita")
                        .WithMany("Porcoes")
                        .HasForeignKey("ReceitaId");
                });
#pragma warning restore 612, 618
        }
    }
}
