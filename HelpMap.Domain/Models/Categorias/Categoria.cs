using HelpMap.Domain.Models.Categorias;
using HelpMap.Domain.Models.Grupos;
using System.Collections.Generic;

namespace HelpMap.Domain.Models.Categories
{
    public class Categoria : Entity
    {
        public Categoria(){}
        public string Nome { get; set; }
        public List<Grupo> Grupos { get; set; }
        public List<Informacao> Informacoes { get; set; }
    }
}
