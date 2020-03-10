using Restaurante.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.IngredienteCategorias
{
    public class IngredienteCategoriaCommandResult: CommandResult
    {
        public IngredienteCategoriaCommandResult(Guid id)
        {
            Id = id;
        }
        public IngredienteCategoriaCommandResult()
        {

        }

        public Guid Id { get; set; }

    }
}
