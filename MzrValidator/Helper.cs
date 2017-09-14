using System;
using System.Collections.Generic;
using System.Linq;

namespace Mzr.Validation {
    public static class Helper {
        public static string GetPassportNo(MzrInput input) {
            var length = Math.Min(9, input.Mzr.Length);
            return input.Mzr.Substring(0, length);
        }

        public static string GetPassportCheckDigit(MzrInput input) {
            if (input.Mzr.Length < 10) {
                return "";
            }

            return input.Mzr.Substring(9, 1);
        }

        public static string InputPad(string value, int length) {
            return value.ToUpper().PadRight(length, '<');
        }

        private static readonly Dictionary<Char, Int16> CheckDigitMap = new Dictionary<Char, Int16> {
            { '<', 0 },
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 },
            { 'G', 16 },
            { 'H', 17 },
            { 'I', 18 },
            { 'J', 19 },
            { 'K', 20 },
            { 'L', 21 },
            { 'M', 22 },
            { 'N', 23 },
            { 'O', 24 },
            { 'P', 25 },
            { 'Q', 26 },
            { 'R', 27 },
            { 'S', 28 },
            { 'T', 29 },
            { 'U', 30 },
            { 'V', 31 },
            { 'W', 32 },
            { 'X', 33 },
            { 'Y', 34 },
            { 'Z', 35 },
        };

        public static int CalculateCheckDigit(string value) {
            // Convert to a character array.
            var checkArr = value.ToCharArray();

            // Lookup for each character in the array, a value
            // from the check-digit-map, and create a new integer array.
            short[] valArr;
            try {
                valArr = (from v in checkArr
                         select CheckDigitMap[v]).ToArray();
            } catch (KeyNotFoundException _) {
                return 0;
            }

            var total = 0;
            for (var idx = 0; idx < valArr.Count(); idx++) {
                // For each value, if it is the first, multiply by 7.
                // If it's the second, multiply by 3.  Otherwise, multiply
                // by 1 (Return the value).  This is done by using the modulo
                // operator.
                total += valArr[idx] * idx % 3 == 0 ? 7 : idx % 3 == 1 ? 3 : 1;
            }

            // Returns the remainder from the running total, divided by 10.
            return total % 10;
        }
    }
}