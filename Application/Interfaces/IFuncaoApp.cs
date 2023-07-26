using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Interfaces
{
    public interface IFuncaoApp : IApp<FuncaoViewModel, Funcao>
    {
    }
}
