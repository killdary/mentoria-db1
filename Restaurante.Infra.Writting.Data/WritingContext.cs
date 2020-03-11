using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurante.Application.Common.Interfaces;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Restaurante.Infra.Writting.Data
{
    public class WritingContext : DbContext, IApplicationDbContext
    {
        private readonly string _writingConnectionString;


        public WritingContext()
        { }

        public WritingContext(DbContextOptions options) : base(options) { }

        public WritingContext(string writingConnectionString)
        {
            _writingConnectionString = writingConnectionString;
        }


        public DbSet<IngredienteCategoria> IngredienteCategorias { get; set; }

        public DbSet<Domain.Entities.Ingrediente> Ingredientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!string.IsNullOrEmpty(_writingConnectionString))
                {
                    optionsBuilder.UseSqlServer(_writingConnectionString);
                }
                else
                {
                    var configuration = new ConfigurationBuilder()
                       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                       .AddJsonFile("appsettings.develop.json")
                       .Build();

                    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Entity<Receita>()
                .HasMany(c => c.Porcoes)
                .WithOne(e => e.Receita);


            modelBuilder.Entity<Receita>()
                .HasMany(c => c.Passos)
                .WithOne(e => e.Receita);
            
            modelBuilder.Entity<IngredienteCategoria>()
                .HasMany(c => c.Ingredientes)
                .WithOne(e => e.IngredienteCategoria);


            base.OnModelCreating(modelBuilder);
        }
    }
}
