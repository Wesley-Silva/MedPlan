using System;

namespace MedPlan.Entities.Models
{
    public class Procedimento : Entity
    {        
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
