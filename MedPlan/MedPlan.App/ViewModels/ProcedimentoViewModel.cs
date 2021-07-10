using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedPlan.App.ViewModels
{
    public class ProcedimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }        

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public decimal Valor { get; set; }        
    }
}
