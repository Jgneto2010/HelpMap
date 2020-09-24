using HelpMap.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Models.Categorias
{
    public class Informacao : Entity
    {
        public Informacao(){}
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Categoria Categoria { get; set; }
    }
}
