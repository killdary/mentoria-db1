using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infra.Writting.Data.Configurations
{
    public class IngredienteCategoriaConfiguration : IEntityTypeConfiguration<IngredienteCategoria>
    {
        public void Configure(EntityTypeBuilder<IngredienteCategoria> builder)
        {

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder
                .Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder.Ignore(p => p.ValidationResult);
        }
    }
}
