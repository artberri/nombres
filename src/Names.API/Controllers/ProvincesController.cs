using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Names.Domain.Entities;
using Names.Infrastructure.Repositories;

namespace Names.API.Controllers
{
    [Route("api/provinces")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly ProvinceRepository _provinceRepository;

        public ProvincesController(ProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        [HttpGet]
        public ActionResult<List<Province>> Get()
        {
            var provinces = _provinceRepository.Get();

            return provinces.ToList();
        }
    }
}
