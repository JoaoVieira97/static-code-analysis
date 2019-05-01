using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F3M.UMinho.Esocial.Units.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValenciasController : ControllerBase
    {
        readonly IValenciasRepository _ValenciasRepository;

        public ValenciasController(IValenciasRepository ValenciasRepository)
        {
            _ValenciasRepository = ValenciasRepository;
        }

        // GET api/valencias/
        [HttpGet]
        public async Task<List<TbValencias>> Get()
        {
            return await _ValenciasRepository.Get(_ValenciasRepository);
        }

        // GET api/utentes/5
        [HttpGet("{id}")]
        public async Task<List<TbValencias>> Get(long id)
        {
            return await _ValenciasRepository.Get(_ValenciasRepository,id);
        }
    }
}
