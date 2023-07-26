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
    public class SetorApp : App<SetorViewModel, Setor>, ISetorApp
    {
        public SetorApp(ILogger<SetorApp> logger, IMapper mapper, ISetorRepository setorRepository) : base(logger, mapper, setorRepository)
        {

        }
    }
}
