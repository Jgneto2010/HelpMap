using HelpMap.Domain.Models.Reunioes;
using System.Collections.Generic;

namespace HelpMap.Domain.Interfaces
{
    public interface IReuniaoAbertaRepository : IRepository<ReuniaoAberta>
    {
        List<ReuniaoAberta> GetReuniaoAbertaGrupo(int idGrupo);
    }
}
