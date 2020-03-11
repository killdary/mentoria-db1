using FluentValidation;
using Restaurante.Application.Ingredientes.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.Ingredientes.Validations
{
    public class UpdateIngredienteCommandValidation: IngredienteCommandValidation<UpdateIngredienteCommand>
    {
        public UpdateIngredienteCommandValidation()
        {
            ValidarId();
            ValidarDescricao();
            ValidarIngredienteCategoriaId();
        }
    }
}
