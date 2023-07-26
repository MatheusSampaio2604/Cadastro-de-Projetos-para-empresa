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
    public class GerenciaApp : App<GerenciaViewModel, Gerencia>, IGerenciaApp
    {
        public GerenciaApp(ILogger<GerenciaApp> logger, IMapper mapper, IGerenciaRepository gerenciaRepository) : base(logger, mapper, gerenciaRepository)
        {

        }
    }
}

