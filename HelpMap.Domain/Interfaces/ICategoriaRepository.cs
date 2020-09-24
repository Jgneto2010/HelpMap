using HelpMap.Domain.Models.Categories;
using System.Collections.Generic;

namespace HelpMap.Domain.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Categoria GetByIdCategoria(int idCategoria);
    }
}
