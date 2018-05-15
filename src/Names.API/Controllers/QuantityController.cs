using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Names.Domain.Entities;
using Names.Infrastructure.Repositories;

namespace Names.API.Controllers
{
    [Route("api/quantities")]
    [ApiController]
    public class QuantityController : ControllerBase
    {
        private readonly QuantityRepository _quantityRepository;

        public QuantityController(QuantityRepository quantityRepository)
        {
            _quantityRepository = quantityRepository;
        }

        [HttpGet("{nameId}")]
        public ActionResult<List<Quantity>> GetByName(int nameId)
        {
            var quantities = _quantityRepository.GetByName(nameId);

            return quantities.ToList();
        }
    }
}
