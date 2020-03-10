using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Queries
{
    public interface IQuery : IRequest
    {}

    public interface IQuery<out TResult>: IRequest<TResult> where TResult: IQueryResult
    {}



}
