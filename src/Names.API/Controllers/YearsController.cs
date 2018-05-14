using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Names.Domain.Entities;
using Names.Infrastructure.Repositories;

namespace Names.API.Controllers
{
    [Route("api/years")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Year>> Get()
        {
            var years = YearRepository.Get();

            return years;
        }
    }
}
