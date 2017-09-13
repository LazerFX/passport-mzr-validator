namespace Mzr.ValidationEngine {
    // A validation Engine for a Type, holds multiple individual Validators.
    public interface IValidator<T> {
        IValidation<T>[] Validations {get;set;}
        ValidationResult[] Validate(T input);
    }
}