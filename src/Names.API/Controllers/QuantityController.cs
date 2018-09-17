using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("{nameId}/byprovince/{provinceId}")]
        public ActionResult<List<Quantity>> GetByNameAndProvince(int nameId, int provinceId)
        {
            var quantities = _quantityRepository.GetByNameAndProvince(nameId, provinceId);

            return quantities.ToList();
        }
    }
}
