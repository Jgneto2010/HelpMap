using HelpMap.Domain.Models.Grupos;
using System;

namespace HelpMap.ViewModels
{
    public class EventoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Aberto { get; set; }
        public bool Gratuito { get; set; }
        public decimal? Valor { get; set; }
        public DateTime Dia { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public int IdGrupo { get; set; }
        public int Id { get; set; }
    }
}
