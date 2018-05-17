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

        [HttpGet("{nameId}/byprovince/{provinceId}")]
        public ActionResult<List<Quantity>> GetByNameAndProvince(int nameId, int provinceId)
        {
            var quantities = _quantityRepository.GetByNameAndProvince(nameId, provinceId);

            return quantities.ToList();
        }

        [HttpGet("{nameId}/byyear/{yearId}")]
        public ActionResult<List<Quantity>> GetByNameAndYear(int nameId, int yearId)
        {
            var quantities = _quantityRepository.GetByNameAndYear(yearId, yearId);

            return quantities.ToList();
        }

        [HttpGet("{nameId}/byprovince/{provinceId}/byyear/{yearId}")]
        public ActionResult<List<Quantity>> GetByNameAndProvinceAndYear(int nameId, int provinceId, int yearId)
        {
            var quantities = _quantityRepository.GetByNameAndProvinceAndYear(nameId, provinceId, yearId);

            return quantities.ToList();
        }
    }
}
