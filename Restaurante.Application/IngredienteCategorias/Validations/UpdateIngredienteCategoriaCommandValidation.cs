using Restaurante.Application.IngredienteCategorias.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.IngredienteCategorias.Validations
{
    public class UpdateIngredienteCategoriaCommandValidation : IngredienteCategoriaCommandValidation<UpdateIngredienteCategoriaCommand>
    {
        public UpdateIngredienteCategoriaCommandValidation()
        {
            ValidarId();
            ValidarDescricao();
        }

    }
}
