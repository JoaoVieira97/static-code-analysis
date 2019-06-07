using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain;
using F3M.UMinho.Esocial.Units.Data.F3MESR3S1RepositoriesInterfaces;
using F3M.UMinho.Esocial.Units.Data.F3MRadRepositoriesInterfaces;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Repositories
{
    public class RepositorioUtentes: F3MESR3S1RepositoryBase<TbUtentes>, IUtentesRepository
    {

        public UtentesRepository(F3MESR3S1Context context) : base(context)
        {
        }

        public async Task<List<object>> Get(IUtentesRepository _IUtentesRepository, IEntidadesRegistadasRepository _IEntidadesRegistadasRepository, IEntidadesRepository _IEntidadesRepository, long id)
        {
            List<TbUtentes> Utentes = (await _IUtentesRepository.GetListAsync(x => x.Id == id)).ToList<TbUtentes>();
            List<TbEntidadesRegistadas> EntidadesRegistadas = (await _IEntidadesRegistadasRepository.GetListAsync(x => x.IsActive)).ToList<TbEntidadesRegistadas>();
            List<TbEntidades> Entidades = (await _IEntidadesRepository.GetListAsync(x => x.IsActive)).ToList<TbEntidades>();

            List<object> Data = new List<Object>();

            foreach (var Utente in Utentes)
            {
                TbEntidades Entidade = null;
                long? IdEntidade = EntidadesRegistadas.Find(item => item.Id == Utente.IdentidadeRegistada).Identidade;
                Entidade = Entidades.Find(item => item.Id == IdEntidade);

                Data.Add(Utente.Id);
                Data.Add(Entidade.Nome);
                Data.Add(Entidade.DataNascimento);
                Data.Add(Entidade.FotoCaminho);
            }
            return Data;
        }


        public async Task<List<object>> Get(IUtentesRepository _IUtentesRepository, IEntidadesRegistadasRepository _IEntidadesRegistadasRepository, IEntidadesRepository _IEntidadesRepository)
        {
            List<TbUtentes> Utentes = (await _IUtentesRepository.GetListAsync(x => x.IsActive)).ToList<TbUtentes>();
            List<TbEntidadesRegistadas> EntidadesRegistadas = (await _IEntidadesRegistadasRepository.GetListAsync(x => x.IsActive)).ToList<TbEntidadesRegistadas>();
            List<TbEntidades> Entidades = (await _IEntidadesRepository.GetListAsync(x => x.IsActive)).ToList<TbEntidades>();

            List<object> Data = new List<object>();

            foreach (var Utente in Utentes)
            {
                long? IdEntidade = EntidadesRegistadas.Find(item => item.Id == Utente.IdentidadeRegistada).Identidade;
                Data.Add(Entidades.Find(item => item.Id == IdEntidade));
            }
            return Data;
        }

        public async Task<List<object>> GetByQuarto(IUtentesRepository _IUtentesRepository, IEntidadesRegistadasRepository _IEntidadesRegistadasRepository, IEntidadesRepository _IEntidadesRepository, IRADCabecalhoRepository _IRADCabecalhoRepository, long id)
        {
            List<object> Entidades = new List<object>();
            List<long> UtenteIds = await _IRADCabecalhoRepository.GetByQuarto(_IRADCabecalhoRepository, id);
            foreach (var Id in UtenteIds)
            {
                Entidades.Add(await this.Get(_IUtentesRepository, _IEntidadesRegistadasRepository, _IEntidadesRepository, Id));
            }
            return Entidades;
        }
    }
}
