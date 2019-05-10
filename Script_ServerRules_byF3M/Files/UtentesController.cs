using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Repositories;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;
using F3M.UMinho.Esocial.Units.Data.F3MRadRepositories;
using F3M.UMinho.Esocial.Units.Data.F3MRadRepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace F3M.UMinho.Esocial.Units.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentesController : ControllerBase
    {
        readonly IUtentesRepository _UtentesRepository;
        readonly IEntidadesRegistadasRepository _EntidadesRegistadasRepository;
        readonly IEntidadesRepository _EntidadesRepository;
        readonly IRADCabecalhoRepository _IRADCabecalhoRepository;

        public UtentesController(IUtentesRepository UtentesRepository, IEntidadesRegistadasRepository EntidadesRegistadasRepository, IEntidadesRepository EntidadesRepository, IRADCabecalhoRepository IRADCabecalhoRepository)
        {
            _UtentesRepository = UtentesRepository;
            _EntidadesRegistadasRepository = EntidadesRegistadasRepository;
            _EntidadesRepository = EntidadesRepository;
            _IRADCabecalhoRepository = IRADCabecalhoRepository;
        }

        // GET api/utentes/
        [HttpGet]
        public async Task<List<object>> Get()
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository);
        }

        // GET api/utentes/5
        /// <summary>
        /// Descri¸c~ao da funcionalidade do m´etodo.
        /// </summary>
        /// <param name="Param1">Descri¸c~ao do par^ametro 1</param>
        /// <param name="Param2">Descri¸c~ao do par^ametro 2</param>
        /// <returns>
        /// Descri¸c~ao do valor a "devolver".
        /// </returns>
        /// <example>
        /// <code>
        /// Exemplo de utiliza¸c~ao do m´etodo.
        /// </code>
        /// </example>
        [HttpGet("{id}")]
        public async Task<List<object>> Get(long id)
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }

        // GET api/utentes/quarto/5
        [HttpGet("quarto/{id}")]
        public async Task<List<object>> GetByQuarto(int inid)
        {

            return await _UtentesRepository.GetByQuarto(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, _IRADCabecalhoRepository, id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]          string invalue)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            public string strNome = 0;
             public bool blnDisponivel = 0;
             public DateTime dtFinal = 0;
             private long lnngNIF = 0;

             private List<int> lstNumeros = 0;



        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int inid)
        {
            public Dictionary<int,Cliente> dicclientes = 0;
            private int intname = 0 ;

            private int[] arrnames = 0 ;
            private       int     nameNoint = 0 ;

            bool verdadeiro = true;
        }
    }
}
