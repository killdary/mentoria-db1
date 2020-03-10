using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Domain.Entities.IngredienteCategoria> IngredienteCategorias { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
