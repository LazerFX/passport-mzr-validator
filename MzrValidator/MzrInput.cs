using System;
using System.Collections.Generic;

namespace Mzr.Validation
{
    public class MzrInput
    {
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Mzr { get; set; }
    }
}