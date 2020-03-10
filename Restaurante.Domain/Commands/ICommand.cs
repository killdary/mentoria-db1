using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Commands
{

    public interface ICommand : IRequest
    {
        ValidationResult ValidationResult { get; set; }
    }

    public interface ICommand<out TResult> : IRequest<TResult> where TResult : ICommandResult
    {
        ValidationResult ValidationResult { get; set; }
    }


}
