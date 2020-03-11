using MediatR;
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
    public class CreateIngredienteCommand : IngredienteCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new CreateIngredienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CreateIngredienteCommandHandler : IRequestHandler<CreateIngredienteCommand, IngredienteCommandResult>
        {

            private readonly IApplicationDbContext _context;

            public CreateIngredienteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IngredienteCommandResult> Handle(CreateIngredienteCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new IngredienteCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = new Ingrediente()
                {
                    Descricao = request.Descricao
                };

                _context.Ingredientes.Add(entity);


                await _context.SaveChangesAsync(cancellationToken);

                return new IngredienteCommandResult(entity.Id);
            }
        }
    }
}
