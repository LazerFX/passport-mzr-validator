using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mzr.ValidationEngine
{
    // A result from validations
    public class ValidationResult
    {
        public string Field { get; set; }
        public string Message { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ValidationStatus Status { get; set; }

        public ValidationResult() {
            Field = "";
            Message = "";
            Status = ValidationStatus.Error;
        }
        public ValidationResult(string field, string message, ValidationStatus status) {
            Field = field;
            Message = message;
            Status = status;
        }
    }
}