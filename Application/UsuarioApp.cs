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
    public class UsuarioApp : App<UsuarioViewModel, Usuario>, IUsuarioApp
    {
        public UsuarioApp(ILogger<UsuarioApp> logger, IMapper mapper, IUsuarioRepository usuarioRepository) : base(logger, mapper, usuarioRepository)
        {

        }
    }
}
