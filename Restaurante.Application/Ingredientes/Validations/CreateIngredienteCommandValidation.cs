using Restaurante.Application.Ingredientes.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.Ingredientes.Validations
{
    public class CreateIngredienteCommandValidation : IngredienteCommandValidation<CreateIngredienteCommand>
    {
        public CreateIngredienteCommandValidation()
        {
            ValidarDescricao();
            ValidarIngredienteCategoriaId();
        }
    }
}
