using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;

namespace F3M.UMinho.Esocial.Units.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentesValenciasController : Controller
    {
        readonly IUtentesValenciaRepository _UtentesValenciaRepository;

        public UtentesValenciasController(IUtentesValenciaRepository UtentesValenciaRepository)
        {
            _UtentesValenciaRepository = UtentesValenciaRepository;
        }

        // GET api/utentesvalencia/
        [HttpGet]
        public async Task<List<TbUtentesValencias>> Get()
        {
            return await _UtentesValenciaRepository.Get(_UtentesValenciaRepository);
        }

        // GET api/utentesvalencia/getIDSalasByValencia
        [HttpGet("getIDSalasByValencia/{id}")]
        public async Task<List<long?>> GetByValencia(long id)
        {
            return await _UtentesValenciaRepository.GetIDSalasByValencia(_UtentesValenciaRepository, id);
        }
    }
}