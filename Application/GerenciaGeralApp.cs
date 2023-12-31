﻿using Application.Interfaces;
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
    public class GerenciaGeralApp : App<GerenciaGeralViewModel, GerenciaGeral>, IGerenciaGeralApp
    {
        public GerenciaGeralApp(ILogger<GerenciaGeralApp> logger, IMapper mapper, IGerenciaGeralRepository gerenciaGeralRepository) : base(logger, mapper, gerenciaGeralRepository)
        {

        }
    }
}
