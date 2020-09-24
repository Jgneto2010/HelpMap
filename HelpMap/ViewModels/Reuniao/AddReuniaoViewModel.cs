using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels
{
    public class AddReuniaoViewModel
    {
        public string Dia { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int  IdGrupo { get; set; }
    }
}
