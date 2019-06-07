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
        /// Descrição da funcionalidade do método.
        /// </summary>
        /// <param name="Param1">Descrição do parâmetro 1</param>
        /// <param name="Param2">Descrição do parâmetro 2</param>
        /// <returns>
        /// Descrição do valor a "devolver".
        /// </returns>
        /// <example>
        /// <code>
        /// Exemplo de utilização do método.
        /// </code>
        /// </example>
        [HttpGet("{id}")]
        public async Task<List<object>> Get(long id)
        {
            // This is a comment
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
        public void Post([FromBody] string invalue) {
            /* teste 1 */
            int i = 0;
            /* teste 2 */
            // ok
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            Console.WriteLine(" { axx{xx {xxx " + ' { asdsa'  "{das" '{dasd' + 
                              " } xx}asxxdasd }x " + ' } asdsa' + "}das" + '}dasd' +
                              " { adxxasd{asxdasd {d}axsd " + ' { asdsa' + "{da}s" '{dasd}');
            int i;
            for (i = 0; i < 5; i++){
                Console.WriteLine(i);
                if (i == 1){
                    Console.WriteLine("Yes!");
                }
            }
            /* declaração de variaveis em baixo */
            string strNome = "nome";
            bool blnDisponivel = true;
            DateTime dtFinal;
            long lnngNIF = 10;
            List<int> lstNumeros;
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int inid)
        {
            Dictionary<int,Cliente> dicclientes = 0;
            int intname = 0;

            int[] arrnames = [];
            int nameNoint = 0;

            bool verdadeiro = true;
        }
    }

    public class Utentes_Controller_2 : ControllerBase
    {
        readonly IUtentesRepository _UtentesRepository;
        readonly IEntidadesRegistadasRepository _EntidadesRegistadasRepository;
        readonly IEntidadesRepository _EntidadesRepository;
        readonly IRADCabecalhoRepository _IRADCabecalhoRepository;

        public Utentes_Controller_2(IUtentesRepository UtentesRepository, IEntidadesRegistadasRepository EntidadesRegistadasRepository, IEntidadesRepository EntidadesRepository, IRADCabecalhoRepository IRADCabecalhoRepository)
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
            // return value
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository);
        }
    }
}
