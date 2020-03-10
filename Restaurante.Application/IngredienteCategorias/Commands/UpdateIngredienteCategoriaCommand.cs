using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Common.Interfaces;
using Restaurante.Application.IngredienteCategorias.Validations;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.IngredienteCategorias.Commands
{
    public class UpdateIngredienteCategoriaCommand : IngredienteCategoriaCommand
    {

        public override bool IsValid()
        {
            ValidationResult = new UpdateIngredienteCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateIngredienteCategoriaCommand, IngredienteCategoriaCommandResult>
        {
            private readonly IApplicationDbContext _context;

            public UpdateTodoItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IngredienteCategoriaCommandResult> Handle(UpdateIngredienteCategoriaCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new IngredienteCategoriaCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = await _context.IngredienteCategorias.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (entity == null)
                {
                    var response = new IngredienteCategoriaCommandResult();
                    response.AddNotification(nameof(IngredienteCategoria), "Registro não foi encontrado");
                    return response;
                }

                entity.AlterarDados(request.Descricao);
                _context.IngredienteCategorias.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new IngredienteCategoriaCommandResult(entity.Id);
            }
        }
    }
}
