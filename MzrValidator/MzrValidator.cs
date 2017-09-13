using System;
using System.Text.RegularExpressions;
using Mzr.ValidationEngine;

namespace Mzr.Validation
{
    public static class MzrValidator
    {
        private static readonly Func<MzrInput, ValidationResult>[] validations = 
        new Func<MzrInput, ValidationResult>[] {
            MzrValidations.MustHaveAZ09LessThan.Validate
        };
        private static Validator<MzrInput> validator = new Validator<MzrInput>(validations);

        public static ValidationResult[] Validate(MzrInput input) {
            return validator.Validate(input);
        }
    }

    namespace MzrValidations {
        public static class MustHaveAZ09LessThan {
            public static ValidationResult returnValue = new ValidationResult {
                Field = "Mzr",
                Message = "Mzr must be made up of A-Z, 0-9 or <"
            };

            public static ValidationResult Validate(MzrInput input) {
                var valid = Regex.IsMatch(input.Mzr, "^[0-9A-Z<]+$");
                if (!valid) {
                    returnValue.Status = ValidationStatus.Error;
                    return returnValue;
                } else {
                    returnValue.Status = ValidationStatus.Valid;
                    return returnValue;
                }
            }
        }
    }
}