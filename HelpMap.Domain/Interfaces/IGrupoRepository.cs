using HelpMap.Domain.Filtros;
using HelpMap.Domain.Models;
using HelpMap.Domain.Models.Grupos;
using System;
using System.Collections.Generic;

namespace HelpMap.Domain.Interfaces
{
    public interface IGrupoRepository : IRepository<Grupo>
    {
        List<Grupo> GetAllGrupos();
        Grupo GetByIdGrupo(int id);
        List<Grupo> GetGruposCategoria(int idCategoria);
        Grupo GetByName(string nomeGrupo);
        List<Grupo> GetGruposPorFiltro(int idCategoria, FiltroBuscaGrupo filtroBuscaGrupo);
    }
}
