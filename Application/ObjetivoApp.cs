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
    public class ObjetivoApp : App<ObjetivoViewModel, Objetivo>, IObjetivoApp
    {
        public ObjetivoApp(ILogger<ObjetivoApp> logger, IMapper mapper, IObjetivoRepository objetivoRepository) : base(logger, mapper, objetivoRepository)
        {

        }
    }
}
