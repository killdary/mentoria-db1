using Restaurante.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.Ingredientes
{
    public abstract class IngredienteCommand :Command<IngredienteCommandResult>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IngredienteCategoriaId { get; set; }

    }
}
