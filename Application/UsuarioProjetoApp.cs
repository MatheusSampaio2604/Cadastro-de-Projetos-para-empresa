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
    public class UsuarioProjetoApp : App<UsuarioProjetoViewModel, UsuarioProjeto>, IUsuarioProjetoApp
    {
        public UsuarioProjetoApp(ILogger<UsuarioProjetoApp> logger, IMapper mapper, IUsuarioProjetoRepository usuarioProjetoRepository) : base(logger, mapper, usuarioProjetoRepository)
        {

        }
    }
}

