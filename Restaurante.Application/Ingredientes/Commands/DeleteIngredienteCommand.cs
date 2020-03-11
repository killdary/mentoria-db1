using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Common.Interfaces;
using Restaurante.Application.Ingredientes.Validations;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Ingredientes.Commands
{
    public class DeleteIngredienteCommand : IngredienteCommand
    {

        public override bool IsValid()
        {
            ValidationResult = new DeleteIngredienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DeleteIngredienteCommandHandler : IRequestHandler<DeleteIngredienteCommand, IngredienteCommandResult>
        {
            private readonly IApplicationDbContext _context;

            public DeleteIngredienteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IngredienteCommandResult> Handle(DeleteIngredienteCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new IngredienteCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = await _context.Ingredientes.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (entity == null)
                {
                    var response = new IngredienteCommandResult();
                    response.AddNotification(nameof(Ingrediente), "Registro não foi encontrado");
                    return response;
                }

                _context.Ingredientes.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new IngredienteCommandResult(entity.Id);
            }
        }
    }
}
