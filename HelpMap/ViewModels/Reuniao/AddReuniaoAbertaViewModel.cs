using System;

namespace HelpMap.ViewModels.Reuniao
{
    public class AddReuniaoAbertaViewModel
    {
        public string Dia { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int IdGrupo { get; set; }
    }
}
