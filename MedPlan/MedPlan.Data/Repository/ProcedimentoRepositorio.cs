using MedPlan.Data.Context;
using MedPlan.Domain.Interfaces.InterfaceProcedimento;
using MedPlan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedPlan.Data.Repository
{
    public class ProcedimentoRepositorio : Repositorio<Procedimento>, IProcedimentoRepositorio
    {
        public ProcedimentoRepositorio(ContextBase context)
            : base(context)
        {

        }
    }
}
