using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjetoApp : IApp<ProjetoViewModel, Projeto>
    {
        Task<Projeto> CreateAsync(ProjetoViewModel projetoViewModel);
        Task<ProjetoViewModel> EditAsync(ProjetoViewModel projetoViewModel);

       

    //    Task<ProjetoViewModel> RemoveUserFromProject(ProjetoViewModel projetoViewModel);
    }
}
