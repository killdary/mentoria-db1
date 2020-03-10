using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Restaurante.Domain.Notifications
{
    public abstract class Notification : INotification
    {

        [IgnoreDataMember]
        public ValidationResult ValidationResult { get; protected set; }
        protected Notification()
        {
            ValidationResult = new ValidationResult();
        }

        public void CopyErrorsFrom(Notification notification)
        {
            AddNotification(notification.ValidationResult.Errors);
        }


        public void CopyErrorsFromValidations(ValidationResult validation)
        {
            AddNotification(validation.Errors);
        }
        public void AddNotification(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        protected void AddNotification(IList<ValidationFailure> erros)
        {
            if (!(erros is null) && erros.Any())
            {
                foreach (var erro in erros)
                {
                    ValidationResult.Errors.Add(erro);
                }
            }
        }

        protected void ClearNotification()
        {
            ValidationResult.Errors.Clear();
        }

        public virtual bool IsValid()
        {
            return !ValidationResult.Errors.Any();
        }
    }
}
