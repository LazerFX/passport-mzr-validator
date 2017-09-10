using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace passport_mzr_validator.Controllers
{
    [Route("api/[controller]")]
    public class MzrDataController : Controller
    {
        [HttpPost("[action]")]
        public MzrValidationResult ValidateMzr([FromBody]MzrInput mzr)
        {
            if (mzr.Mzr == "testvalue")
            {
                return new MzrValidationResult
                {
                    Valid = true,
                    Message = "Data is valid."
                };
            }
            return new MzrValidationResult
            {
                Valid = false,
                Message = "Data did not match test pattern."
            };
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class MzrInput
    {
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Mzr { get; set; }
    }

    public class MzrValidationResult
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}