using Restaurante.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.Ingredientes
{
    public class IngredienteCommandResult : CommandResult
    {
        public IngredienteCommandResult(Guid id)
        {
            Id = id;
        }
        public IngredienteCommandResult()
        {

        }

        public Guid Id { get; set; }
    }
}
