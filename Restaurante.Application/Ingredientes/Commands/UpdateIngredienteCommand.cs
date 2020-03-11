using MediatR;
using Restaurante.Application.Common.Interfaces;
using Restaurante.Application.Ingredientes.Validations;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Ingredientes.Commands
{
    public class UpdateIngredienteCommand : IngredienteCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateIngredienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateIngredienteCommandHandler : IRequestHandler<UpdateIngredienteCommand, IngredienteCommandResult>
        {

            private readonly IApplicationDbContext _context;

            public UpdateIngredienteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IngredienteCommandResult> Handle(UpdateIngredienteCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new IngredienteCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = _context.Ingredientes.FirstOrDefault(x => x.Id == request.Id);

                if (entity == null)
                {
                    var response = new IngredienteCommandResult();
                    response.AddNotification(nameof(IngredienteCategoria), "Registro não foi encontrado");
                    return response;
                }

                _context.Ingredientes.Add(entity);


                await _context.SaveChangesAsync(cancellationToken);

                return new IngredienteCommandResult(entity.Id);
            }
        }
    }
}
