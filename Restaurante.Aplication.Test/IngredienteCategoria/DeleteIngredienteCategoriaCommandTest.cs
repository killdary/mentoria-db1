using Restaurante.Application.IngredienteCategorias.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Restaurante.Aplication.Test.IngredienteCategoria
{
    public class DeleteIngredienteCategoriaCommandTest
    {

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(DeleteIngredienteCategoriaCommand))]
        public void AoInstanciarSeValidoNaoDeveRetornarNotification()
        {
            var command = new DeleteIngredienteCategoriaCommand
            {
                Id = Guid.NewGuid()
            };

            Assert.True(command.IsValid());
            Assert.False(command.ValidationResult.Errors.Any());
        }

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(DeleteIngredienteCategoriaCommand))]
        public void AoInstanciarSeInvalidoDeveRetornarNotification()
        {
            var command = new DeleteIngredienteCategoriaCommand();

            Assert.False(command.IsValid());
            Assert.True(command.ValidationResult.Errors.Any());
        }
    }
}
