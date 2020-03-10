using Restaurante.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.IngredienteCategorias
{
    public abstract class IngredienteCategoriaCommand : Command<IngredienteCategoriaCommandResult>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
