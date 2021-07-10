using AutoMapper;
using MedPlan.App.ViewModels;
using MedPlan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPlan.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {            
            CreateMap<Procedimento, ProcedimentoViewModel>().ReverseMap();            
        }
    }
}
