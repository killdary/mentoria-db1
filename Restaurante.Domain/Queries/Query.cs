using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Queries
{
    public abstract class Query<TResult> : IQuery<TResult> where TResult: IQueryResult
    {

    }
}
