using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Models.Grupos
{
    public class Evento : Entity
    {
        public string Titulo{ get; set; }
        public string Descricao { get; set; }
        public bool Aberto { get; set; }
        public bool Gratuito { get; set; }
        public decimal? Valor { get; set; }
        public DateTime Dia { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public int? IdGrupo { get; set; }
        public Grupo Grupo { get; set; }
    }
}
