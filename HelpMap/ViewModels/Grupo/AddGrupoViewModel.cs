using FluentValidation;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Domain.Models.Reunioes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels
{
    public class AddGrupoViewModel 
    {
        public string Nome { get; set; }
        public AddEnderecoViewModel Endereco { get; set; }
        public int IdCategoria { get; set; }
    }
}
