namespace Mzr.ValidationEngine
{
    // A result from validations
    public class ValidationResult
    {
        public string Field { get; set; }
        public string Message { get; set; }
        public ValidationStatus Status { get; set; }
    }
}