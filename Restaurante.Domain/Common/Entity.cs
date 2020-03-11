using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime DateUpdate { get; protected set; }

        [IgnoreDataMember, NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            DateCreate = DateTime.Now;
            DateUpdate = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
        
        protected void AddNotification(string propertyName, string errorMessage)
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


    }
}
