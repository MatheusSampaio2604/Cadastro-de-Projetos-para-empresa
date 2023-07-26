using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class UsuarioProjetoViewModel
    {
        public int Id_Usuario { get; set; }

        public int Id_Funcao { get; set; }

        public int Id_Projeto { get; set; }

       public virtual UsuarioViewModel? Usuario { get; set; } 
    }
}
