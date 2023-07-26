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
    public class AnexosApp : App<AnexosViewModel, Anexos>, IAnexosApp
    {
        public AnexosApp(ILogger<AnexosApp> logger, IMapper mapper, IAnexosRepository anexos) : base(logger, mapper, anexos)
        {

        }
    }
}
