using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace passport_mzr_validator.Controllers {
    [Route ("api/[controller]")]
    public class MzrDataController : Controller {
        [HttpGet ("[action]")]
        public MzrValidationData ValidateMzr (string mzr) {
            if (mzr == "testvalue") {
                return new MzrValidationData { 
                    Valid = true,
                    Message = "Data is valid."
                };
            }
            return new MzrValidationData {
                Valid = false,
                Message = "Data did not match test pattern."
            };
        }
    }

    public class MzrValidationData {
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}