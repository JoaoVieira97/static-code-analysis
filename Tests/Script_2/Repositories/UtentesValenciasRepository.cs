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

        public async Task<List<TbUtentesValencias>> Get(IUtentesValenciaRepository _IUtentesValenciaRepository)
        {
            return (await _IUtentesValenciaRepository.GetListAsync(x => x.IsActive)).ToList<TbUtentesValencias>();
        }

        public async Task<List<long?>> GetIDSalasByValencia(IUtentesValenciaRepository _IUtentesValenciaRepository, long id)
        {
            List<TbUtentesValencias> utentesValencias = await _IUtentesValenciaRepository.Get(_IUtentesValenciaRepository);
            List<long?> IDSalas = new List<long?>();
            foreach (var valencia in utentesValencias)
            {
                if (valencia.Idvalencia == id && (valencia.DataSaida == null || valencia.DataSaida <= DateTime.Now) && valencia.IsActive)
                {
                    IDSalas.Add(valencia.Idsala);
                }
            }
            return IDSalas;
        }
    }
}
