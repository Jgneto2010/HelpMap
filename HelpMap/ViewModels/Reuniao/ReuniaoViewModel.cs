using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels
{
    public class ReuniaoViewModel
    {
        public string Dia { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int Id { get; set; }
        public int IdGrupo { get; set; }
    }
}
