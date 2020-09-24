using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Reunioes;
using HelpMap.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace HelpMap.Infrastructure.Repository
{
    public class ReuniaoRepository : Repository<Reuniao>, IReuniaoRepository
    {
        public ReuniaoRepository(ContextEntity context) : base(context)
        {
        }

        public List<Reuniao> GetReuniaoGrupo(int idGrupo)
        {
            var result = DbSet
                   .Where(x => x.IdGrupo == idGrupo).ToList();

            return result;
        }
    }
}
