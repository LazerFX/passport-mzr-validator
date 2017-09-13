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
    }
}