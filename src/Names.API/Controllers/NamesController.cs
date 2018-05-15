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
    }
}
