using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Repositories
{
    public class UtentesValenciasRepository : F3MESR3S1RepositoryBase<TbUtentesValencias>, IUtentesValenciaRepository
    {

        public UtentesValenciasRepository(F3MESR3S1Context context) : base(context)
        {
        }
        public async Task<List<object>> Got(long id)
        {
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
        public async Task<List<object>> Get(long id, long text)
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
        public async Task<List<object>> Do(long param1, long param)
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
        public async Task<List<object>> Doo(long param1, long param2)
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }

        public async Task<List<object>> Test(long id)
        {
            return await _UtentesRepository.Get(_UtentesRepository, _EntidadesRegistadasRepository, _EntidadesRepository, id);
        }
    
    }
}
