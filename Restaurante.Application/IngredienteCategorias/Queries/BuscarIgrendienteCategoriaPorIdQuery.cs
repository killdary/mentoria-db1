using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Common.Interfaces;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.IngredienteCategorias.Queries
{
    public class BuscarIgrendienteCategoriaPorIdQuery : Query<QueryResult>
    {
        public BuscarIgrendienteCategoriaPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public class TodosIngredienteCategoriasQueryHandler : IRequestHandler<BuscarIgrendienteCategoriaPorIdQuery, QueryResult>
        {
            private readonly IApplicationDbContext _context;

            public TodosIngredienteCategoriasQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<QueryResult> Handle(BuscarIgrendienteCategoriaPorIdQuery request, CancellationToken cancellationToken)
            {
                var ingredienteCategoria = await _context.IngredienteCategorias.FirstOrDefaultAsync(x => x.Id == request.Id);

                return new QueryResult((ingredienteCategoria == null) ? 0 : 1, ingredienteCategoria);
            }
        }
    }
}
