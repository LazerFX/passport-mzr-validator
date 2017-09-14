using System;
using System.Text.RegularExpressions;
using Mzr.ValidationEngine;

namespace Mzr.Validation
{
    public static class MzrValidator
    {
        private static readonly Func<MzrInput, ValidationResult>[] validations =
        new Func<MzrInput, ValidationResult>[] {
            Validations.MustHaveAZ09LessThan,
            Validations.LengthMustBe44Characters
        };
        private static Validator<MzrInput> validator = new Validator<MzrInput>(validations);

        public static ValidationResult[] Validate(MzrInput input)
        {
            return validator.Validate(input);
        }
    }

    public static class Validations
    {
        public static ValidationResult MustHaveAZ09LessThan(MzrInput input)
        {
            var valid = Regex.IsMatch(input.Mzr, "^[0-9A-Z<]+$");

            var returnValue = new ValidationResult("Mzr",
                "Mzr must be made up of A-Z, 0-9 or <", ValidationStatus.Valid);

            if (!valid)
            {
                returnValue.Status = ValidationStatus.Error;
            }

            return returnValue;
        }

        public static ValidationResult LengthMustBe44Characters(MzrInput input) {
            var valid = input.Mzr.Length == 44;
            var returnValue = new ValidationResult("Mzr",
                "Mzr must have a lenght of 44 characters", ValidationStatus.Valid);

            if (!valid) {
                returnValue.Status = ValidationStatus.Error;
            }

            return returnValue;
        }
    }
}