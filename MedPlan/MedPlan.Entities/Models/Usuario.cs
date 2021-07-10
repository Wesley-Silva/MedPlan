using MedPlan.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace MedPlan.Entities.Models
{
    public class Usuario : IdentityUser
    {
        public string CPF { get; set; }

        public string Nome { get; set; }

        public TipoUsuario? Tipo { get; set; }
    }
}
