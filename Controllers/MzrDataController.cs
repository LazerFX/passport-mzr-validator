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
        public MzrOutput ValidateMzr([FromBody]MzrInput mzr)
        {
            var validator = new Mzr.Validation.Validator(mzr);
            return validator.Valid;
        }
    }
}