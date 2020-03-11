using MediatR;
using Restaurante.Application.Common.Interfaces;
using Restaurante.Application.IngredienteCategorias.Validations;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.IngredienteCategorias.Commands
{
    public class CreateIngredienteCategoriaCommand : IngredienteCategoriaCommand
    {

        public override bool IsValid()
        {
            ValidationResult = new CreateIngredienteCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CreatengredienteCategoriaCommandHandler : IRequestHandler<CreateIngredienteCategoriaCommand, IngredienteCategoriaCommandResult>
        {
            private readonly IApplicationDbContext _context;

            public CreatengredienteCategoriaCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IngredienteCategoriaCommandResult> Handle(CreateIngredienteCategoriaCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new IngredienteCategoriaCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = new IngredienteCategoria()
                {
                    Descricao = request.Descricao
                };

                _context.IngredienteCategorias.Add(entity);


                await _context.SaveChangesAsync(cancellationToken);

                return new IngredienteCategoriaCommandResult(entity.Id);
            }
        }
    }
}
