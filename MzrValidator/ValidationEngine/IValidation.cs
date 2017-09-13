namespace Mzr.ValidationEngine
{
    // An individual Validation for a Type.
    public interface IValidation<T>
    {
        ValidationResult Validate(T input);
    }
}