
using HelpMap.Domain.Filtros;
using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;

namespace HelpMap.Infrastructure.Repository
{
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(ContextEntity context) : base(context)
        {

        }

        public List<Grupo> GetAllGrupos()
        {
            return DbSet.Include(x => x.Categoria).Include(x => x.Reunioes).Include(x => x.Endereco).ToList();
        }

        public List<Grupo> GetGruposPorFiltro(int idCategoria, FiltroBuscaGrupo filtroBuscaGrupo)
        {
            double lat = filtroBuscaGrupo.Latidude;
            double lng = filtroBuscaGrupo.Longitude;

            var myLocation = new Point(filtroBuscaGrupo.Latidude, filtroBuscaGrupo.Longitude)
            {
                SRID = 4326
            };

            double radiusMeters = 100000; //100Km
            var result = DbSet
                    .Include(x => x.Categoria)
                    .Include(x => x.Reunioes)
                    .Include(x => x.ReunioesAbertas)
                    .Include(x => x.Endereco)
                    .Include(x => x.Eventos)
                    .Where(x => x.Endereco.Localizacao.Distance(myLocation) <= radiusMeters &&
                           x.IdCategoria == idCategoria).ToList();

            if (filtroBuscaGrupo.DiasSemana.Any())
            {
                var grupos = new List<Grupo>();
                foreach (var dia in filtroBuscaGrupo.DiasSemana)
                {
                    foreach (var item in result)
                    {
                        if (item.Reunioes.Any(x => x.Dia == dia))
                            grupos.Add(item);
                    }
                }

                return grupos;
            }

            return result;
        }


        public List<Grupo> GetGruposCategoria(int idCategoria)
        {
            var result = DbSet
                    .Include(x => x.Categoria)
                    .Include(x => x.Reunioes)
                    .Include(x => x.ReunioesAbertas)
                    .Include(x => x.Endereco)
                    .Include(x => x.Eventos)
                    .Where(x => x.IdCategoria == idCategoria).ToList();

            return result;
        }

        public Grupo GetByIdGrupo(int id)
        {
            return DbSet
                    .Include(x => x.Categoria)
                    .Include(x => x.Reunioes)
                    .Include(x => x.ReunioesAbertas)
                    .Include(x => x.Endereco)
                    .Include(x => x.Eventos)
                .FirstOrDefault(t => t.Id == id);
        }

        public Grupo GetByName(string nomeGrupo)
        {
            return DbSet
                    .Include(x => x.Categoria)
                    .Include(x => x.Reunioes)
                    .Include(x => x.ReunioesAbertas)
                    .Include(x => x.Endereco)
                    .Include(x => x.Eventos)
                .FirstOrDefault(t => t.Nome == nomeGrupo);
        }


    }
}
