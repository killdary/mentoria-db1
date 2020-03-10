using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Commands
{
    public abstract class Command<TResult> : ICommand<TResult> where TResult : ICommandResult
    {

        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
