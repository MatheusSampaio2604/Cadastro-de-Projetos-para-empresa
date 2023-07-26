using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class FuncaoApp : App<FuncaoViewModel, Funcao>, IFuncaoApp
    {
        public FuncaoApp(ILogger<FuncaoApp> logger, IMapper mapper, IFuncaoRepository funcaoRepository) : base(logger, mapper, funcaoRepository)
        {

        }
    }
}
