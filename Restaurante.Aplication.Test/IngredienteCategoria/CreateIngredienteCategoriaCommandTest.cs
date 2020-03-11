using Restaurante.Application.IngredienteCategorias.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Restaurante.Aplication.Test.IngredienteCategoria
{
    public class CreateIngredienteCategoriaCommandTest
    {

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(CreateIngredienteCategoriaCommand))]
        public void AoInstanciarSeValidoNaoDeveRetornarNotification()
        {
            var command = new CreateIngredienteCategoriaCommand
            {
                Descricao = "Categoria"
            };

            Assert.True(command.IsValid());
            Assert.False(command.ValidationResult.Errors.Any());
        }

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(CreateIngredienteCategoriaCommand))]
        public void AoInstanciarSeInvalidoDeveRetornarNotification()
        {
            var command = new CreateIngredienteCategoriaCommand();

            Assert.False(command.IsValid());
            Assert.True(command.ValidationResult.Errors.Any());
        }
    }
}
