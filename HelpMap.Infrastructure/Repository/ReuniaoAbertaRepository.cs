using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Reunioes;
using HelpMap.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace HelpMap.Infrastructure.Repository
{
    public class ReuniaoAbertaRepository : Repository<ReuniaoAberta>, IReuniaoAbertaRepository
    {
        public ReuniaoAbertaRepository(ContextEntity context) : base(context)
        {
        }

        public List<ReuniaoAberta> GetReuniaoAbertaGrupo(int idGrupo)
        {
            var result = DbSet
                   .Where(x => x.IdGrupo == idGrupo).ToList();

            return result;
        }
    }
}
