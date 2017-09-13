using System.Collections.Generic;
using System.Linq;

namespace Mzr.ValidationEngine
{
    public class Validator<T> : IValidator<T>
    {
        public IValidation<T>[] Validations { get; set; }

        public Validator(IValidation<T>[] validations) {
            Validations = validations;
        }

        public ValidationResult[] Validate(T input) {
            var result = new List<ValidationResult>();

            foreach (var validation in Validations) {
                result.Add(validation.Validate(input));
            }

            return result.ToArray();
        }
    }
}