using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Names.Domain.Entities;
using Names.Infrastructure.Repositories;

namespace Names.API.Controllers
{
    [Route("api/names")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly NameRepository _nameRepository;

        public NamesController(NameRepository nameRepository)
        {
            _nameRepository = nameRepository;
        }

        [HttpGet]
        public ActionResult<List<Name>> Get()
        {
            var names = _nameRepository.Get();

            return names.ToList();
        }

        [HttpGet("byprovince/{provinceId}")]
        public ActionResult<List<Name>> GetByProvince(int provinceId)
        {
            var names = _nameRepository.GetByProvince(provinceId);

            return names.ToList();
        }

        [HttpGet("byyear/{yearId}")]
        public ActionResult<List<Name>> GetByYear(int yearId)
        {
            var names = _nameRepository.GetByYear(yearId);

            return names.ToList();
        }

        [HttpGet("byprovince/{provinceId}/byyear/{yearId}")]
        public ActionResult<List<Name>> GetByProvinceAndYear(int provinceId, int yearId)
        {
            var names = _nameRepository.GetByProvinceAndYear(provinceId, yearId);

            return names.ToList();
        }
    }
}
