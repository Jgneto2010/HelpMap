using HelpMap.Domain.Models.Reunioes;
using System.Collections.Generic;

namespace HelpMap.Domain.Interfaces
{
    public interface IReuniaoRepository : IRepository<Reuniao>
    {
        List<Reuniao> GetReuniaoGrupo(int idGrupo);
    }
}
