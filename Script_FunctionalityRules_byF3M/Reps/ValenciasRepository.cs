using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Repositories
{
    public class ValenciasRepository : F3MESR3S1RepositoryBase<TbValencias>, IValenciasRepository
    {
        public ValenciasRepository(F3MESR3S1Context context) : base(context)
        {
        }

        public async Task<List<TbValencias>> Get(IValenciasRepository _IValenciasRepository)
        {
            List<TbValencias> Valencias = (await _IValenciasRepository.GetListAsync(x => x.IsActive)).ToList<TbValencias>();
            return Valencias;
        }

        public async Task<List<TbValencias>> Get(IValenciasRepository _IValenciasRepository, long id)
        {
            List<TbValencias> Valencias = (await _IValenciasRepository.GetListAsync(x => x.Id == id)).ToList<TbValencias>();
            return Valencias;
        }

    }
}
