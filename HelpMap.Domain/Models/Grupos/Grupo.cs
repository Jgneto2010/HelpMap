using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Reunioes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpMap.Domain.Models.Grupos
{
    public class Grupo : Entity
    {
        public Grupo(){}

        public string Nome { get;  set; }
        public string Recado { get; set; }
        public int IdCategoria { get; set; }
        public List<Reuniao> Reunioes { get; set; }
        public List<ReuniaoAberta> ReunioesAbertas { get; set; }
        public List<Evento> Eventos { get; set; }
        public Endereco Endereco { get; set; }
        public virtual Categoria Categoria { get; }
    }
}
