using System;

namespace Mzr.ValidationEngine {
    // A validation Engine for a Type, holds multiple individual Validators.
    public interface IValidator<T> {
        Func<T, ValidationStatus>[] Validations {get;set;}
        ValidationResult[] Validate(T input);
    }
}