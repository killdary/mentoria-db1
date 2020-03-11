using Restaurante.Application.IngredienteCategorias.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Restaurante.Aplication.Test.IngredienteCategoria
{
    public class UpdateIngredienteCategoriaCommandTest
    {

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateIngredienteCategoriaCommand))]
        public void AoInstanciarSeValidoNaoDeveRetornarNotification()
        {
            var command = new UpdateIngredienteCategoriaCommand
            {
                Id = Guid.NewGuid(),
                Descricao = "Categoria"
            };

            Assert.True(command.IsValid());
            Assert.False(command.ValidationResult.Errors.Any());
        }

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateIngredienteCategoriaCommand))]
        public void AoInstanciarSeInvalidoDeveRetornarNotification()
        {
            var command = new UpdateIngredienteCategoriaCommand();

            Assert.False(command.IsValid());
            Assert.True(command.ValidationResult.Errors.Any());
        }
    }
}
