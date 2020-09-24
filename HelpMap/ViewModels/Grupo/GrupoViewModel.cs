using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels
{
    public class GrupoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Recado { get; set; }
        public bool Aberto { get; set; }
        public List<ReuniaoViewModel> Reunioes { get; set; }
        public List<ReuniaoAbertaViewModel> ReunioesAbertas { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public CategoriaViewModel Categoria { get; set; }
    }
}
