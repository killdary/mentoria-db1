using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.IngredienteCategorias.Validations
{
    public class IngredienteCategoriaCommandValidation<T>: AbstractValidator<T> where T: IngredienteCategoriaCommand
    {

        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Campo id é obrigatório.");
        }

        protected void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotNull().WithMessage("Campo não pode ser nulo")
                .NotEmpty().WithMessage("Campo descrição obrigatório.");
        }
    }
}
