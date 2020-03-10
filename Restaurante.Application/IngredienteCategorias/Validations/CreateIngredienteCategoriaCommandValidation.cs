using Restaurante.Application.IngredienteCategorias.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.IngredienteCategorias.Validations
{
    public class CreateIngredienteCategoriaCommandValidation : IngredienteCategoriaCommandValidation<CreateIngredienteCategoriaCommand>
    {
        public CreateIngredienteCategoriaCommandValidation()
        {
            ValidarDescricao();
        }

    }
}
