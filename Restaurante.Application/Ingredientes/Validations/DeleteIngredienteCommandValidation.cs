using Restaurante.Application.Ingredientes.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.Ingredientes.Validations
{
    public class DeleteIngredienteCommandValidation : IngredienteCommandValidation<DeleteIngredienteCommand>
    {
        public DeleteIngredienteCommandValidation()
        {
            ValidarId();
        }
    }
}
