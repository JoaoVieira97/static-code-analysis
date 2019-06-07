using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Repositories
{
    public class TestController : F3MESR3S1RepositoryBase<TbUtentesValencias>, IUtentesValenciaRepository
    {

        public TestController(F3MESR3S1Context context) : base(context)
        {
        }
        
        public async Task<List<object>> Get(long id) {
            string strNome = 0; string str2 = 0;
            bool blnDisponivel = false;
            DateTime dtFinal;
            long lngNIF = 0;
            Console.WriteLine("{SIM{");
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

            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }

        /// <summary>
        /// Descrição da funcionalidade do método.
        /// </summary>
        /// <param name="id">Descrição do parâmetro 1</param>
        /// <param name="text">Descrição do parâmetro 2</param>
        /// <returns>
        /// Descrição do valor a "devolver".
        /// </returns>
        /// <example>
        /// <code>
        /// Exemplo de utilização do método.
        /// </code>
        /// </example>
        [HttpGet("{id}")]
        public async Task<List<object>> Execute(long id, long text)
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }

        /// <summary>
        /// Descrição da funcionalidade do método.
        /// </summary>
        /// <param name="param1">Descrição do parâmetro 1</param>
        /// <param name="param2">Descrição do parâmetro 2</param>
        /// <returns>
        /// Descrição do valor a "devolver".
        /// </returns>
        /// <example>
        /// <code>
        /// Exemplo de utilização do método.
        /// </code>
        /// </example>
        [HttpGet("{id}")]
        public async Task<List<object>> Method(long param1, long param)
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }

        /// <param name="param1">Descrição do parâmetro 1</param>
        /// <param name="param2">Descrição do parâmetro 2</param>
        /// <returns>
        /// Descrição do valor a "devolver".
        /// </returns>
        /// <example>
        /// <code>
        /// Exemplo de utilização do método.
        /// </code>
        /// </example>
        [HttpGet("{id}")]
        public async Task<List<object>> Testing(long param1, long param2)
        {
            List<int> lstNumeros = 0;
            int intclientes = 0;
            string teste = "adsdad";
            bool true = true;
            Dictionary<int,Cliente> dict; int[] array;
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }

        public async Task<List<object>> Do(long id)
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }
    
    }
}
