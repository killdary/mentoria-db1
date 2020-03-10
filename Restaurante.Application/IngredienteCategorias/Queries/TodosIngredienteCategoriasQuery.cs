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
    public class TodosIngredienteCategoriasQuery : Query<QueryResult>
    {

        public class TodosIngredienteCategoriasQueryHandler : IRequestHandler<TodosIngredienteCategoriasQuery, QueryResult>
        {
            private readonly IApplicationDbContext _context;

            public TodosIngredienteCategoriasQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<QueryResult> Handle(TodosIngredienteCategoriasQuery request, CancellationToken cancellationToken)
            {
                var ingredienteCategorias = await _context.IngredienteCategorias.ToListAsync();

                return new QueryResult(ingredienteCategorias.Count, ingredienteCategorias);
            }
        }
    }
}
