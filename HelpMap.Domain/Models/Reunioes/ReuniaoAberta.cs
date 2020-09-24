using HelpMap.Domain.Models.Grupos;
using System;

namespace HelpMap.Domain.Models.Reunioes
{
    public class ReuniaoAberta : Entity
    {
        public ReuniaoAberta() { }
        public string Dia { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Grupo Grupo { get; set; }
        public int? IdGrupo { get; set; }
    }
}
