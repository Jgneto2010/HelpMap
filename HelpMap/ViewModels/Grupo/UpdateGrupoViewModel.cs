using HelpMap.ViewModels.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.Grupo
{
    public class UpdateGrupoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Recado { get; set; }
        public CategoriaViewModel Categoria { get; set; }
        public UpdateEnderecoViewModel Endereco { get; set; }
        public List<ReuniaoViewModel> Reunioes { get; set; }
        public List<ReuniaoAbertaViewModel> ReunioesAbertas { get; set; }
    }
}
