using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Application.Ingredientes.Validations
{
    public class IngredienteCommandValidation<T>: AbstractValidator<T> where T : IngredienteCommand
    {
        protected void ValidarId()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Campo id é obrigatório.");
        }
        
        protected void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotNull().WithMessage("Campo não pode ser nulo")
                .NotEmpty().WithMessage("Campo descrição obrigatório.");
        }
        
        protected void ValidarIngredienteCategoriaId()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Campo id de ingredienteCategoria é obrigatório.");
        }
    }
}
