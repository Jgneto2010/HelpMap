using HelpMap.Domain.Models.Grupos;
using System;

namespace HelpMap.Domain.Models.Reunioes
{
    public class Reuniao : Entity
    {
        public Reuniao(){}
        public string Dia { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Grupo Grupo { get; set; }
        public int? IdGrupo { get; set; }
    }
}
