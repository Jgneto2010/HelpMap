using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels
{
    public class ReuniaoAbertaViewModel
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public string Dia { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
