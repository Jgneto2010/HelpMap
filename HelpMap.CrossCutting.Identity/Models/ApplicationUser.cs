using HelpMap.Domain.Models.Grupos;
using Microsoft.AspNetCore.Identity;

namespace HelpMap.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Grupo Grupo { get; set; }
        public int IdGrupo { get; set; }
    }
}
