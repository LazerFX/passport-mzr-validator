using System;

namespace Mzr.Validation {
    public static class Helper {
        public static string GetPassportNo(MzrInput input) {
            var length = Math.Min(9, input.Mzr.Length);
            return input.Mzr.Substring(0, length);
        }

        public static string InputPad(string value, int length) {
            return value.ToUpper().PadRight(length, '<');
        }
    }
}