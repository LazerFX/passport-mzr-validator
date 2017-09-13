using System.Text.RegularExpressions;
using Mzr.ValidationEngine;

namespace Mzr.Validation
{
    public static class MzrValidator
    {
        private static readonly IValidation<MzrInput>[] validations = new IValidation<MzrInput>[] {
        };
        private static Validator<MzrInput> validator = new Validator<MzrInput>(validations);

        public static ValidationResult[] Validate(MzrInput input) {
            return validator.Validate(input);
        }
    }
}