using System;
using System.Collections.Generic;
using System.Linq;

namespace Mzr.ValidationEngine
{
    public class Validator<T> : IValidator<T>
    {
        public Func<T, ValidationResult>[] Validations { get; set; }

        public Validator(Func<T, ValidationResult>[] validations) {
            Validations = validations;
        }

        public ValidationResult[] Validate(T input) {
            var result = new List<ValidationResult>();

            foreach (var validation in Validations) {
                result.Add(validation(input));
            }

            return result.ToArray();
        }
    }
}