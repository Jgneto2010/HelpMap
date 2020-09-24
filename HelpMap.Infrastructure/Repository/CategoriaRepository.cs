using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Categories;
using HelpMap.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HelpMap.Infrastructure.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ContextEntity context) : base(context)
        {

        }

        public Categoria GetByIdCategoria(int idCategoria)
        {
            var result = DbSet.Include(x => x.Informacoes)
                    .Where(x => x.Id == idCategoria).First();
            return result;
        }

    }
}
