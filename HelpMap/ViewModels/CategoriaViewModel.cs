using System.Collections.Generic;

namespace HelpMap.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<InformacaoViewModel> Informacoes { get; set; }
    }
}
