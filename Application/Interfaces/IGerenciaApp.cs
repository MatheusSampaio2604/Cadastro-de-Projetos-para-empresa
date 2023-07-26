using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.ViewModel;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGerenciaApp : IApp<GerenciaViewModel, Gerencia>
    {
    }
}

