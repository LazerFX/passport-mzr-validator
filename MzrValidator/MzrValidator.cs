using System;
using System.Text.RegularExpressions;
using Mzr.ValidationEngine;

namespace Mzr.Validation
{
    public static class MzrValidator
    {
        private static readonly Func<MzrInput, ValidationStatus>[] validations =
        new Func<MzrInput, ValidationStatus>[] {
            Validations.MustHaveAZ09LessThan,
            Validations.LengthMustBe44Characters,
            Validations.PassportNoAndMzrMustMatch
        };
        private static Validator<MzrInput> validator = new Validator<MzrInput>(validations);

        public static ValidationResult[] Validate(MzrInput input)
        {
            return validator.Validate(input);
        }
    }

    public static class Validations
    {
        [Field("Mzr")]
        [Message("Mzr must be made up of A-Z, 0-9 or <")]
        public static ValidationStatus MustHaveAZ09LessThan(MzrInput input)
        {
            var valid = Regex.IsMatch(input.Mzr, "^[0-9A-Z<]+$");

            return valid ? ValidationStatus.Valid : ValidationStatus.Error;
        }

        [Field("Mzr")]
        [Message("Mzr must have a length of 44 characters")]
        public static ValidationStatus LengthMustBe44Characters(MzrInput input) {
            var valid = input.Mzr.Length == 44;
            return valid ? ValidationStatus.Valid : ValidationStatus.Error;
        }

        [Field("Mzr")]
        [Field("PassportNo")]
        [Message("Passport Number and the MZR Passport area do not match.")]
        public static ValidationStatus PassportNoAndMzrMustMatch(MzrInput input) {
            var inputPassport = Helper.GetPassportNo(input);
            var paddedPassport = Helper.InputPad(input.PassportNo, 9);
            
            return inputPassport == paddedPassport ? ValidationStatus.Valid : ValidationStatus.Warning;
        }
    }
}