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
    public class TemaApp : App<TemaViewModel, Tema>, ITemaApp
    {
        public TemaApp(ILogger<TemaApp> logger, IMapper mapper, ITemaRepository temaRepository) : base(logger, mapper, temaRepository)
        {

        }
    }
}
