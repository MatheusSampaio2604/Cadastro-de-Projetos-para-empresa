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
    public class FinanciamentoApp : App<FinanciamentoViewModel, Financiamento>, IFinanciamentoApp
    {
        public FinanciamentoApp(ILogger<FinanciamentoApp> logger, IMapper mapper, IFinanciamentoRepository financiamentoRepository) : base(logger, mapper, financiamentoRepository)
        {

        }
    }
}

