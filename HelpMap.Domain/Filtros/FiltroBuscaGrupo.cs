using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Filtros
{
    public class FiltroBuscaGrupo
    {
        public List<string> DiasSemana { get; set; }
        public double Latidude { get; set; }
        public double Longitude { get; set; }
    }
}
