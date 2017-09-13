using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mzr.Validation;

namespace passport_mzr_validator.Controllers
{
    [Route("api/[controller]")]
    public class MzrDataController : Controller
    {
        [HttpPost("[action]")]
        public Mzr.ValidationEngine.ValidationResult[] ValidateMzr([FromBody]MzrInput mzr)
        {
            return Mzr.Validation.MzrValidator.Validate(mzr);
        }
    }
}