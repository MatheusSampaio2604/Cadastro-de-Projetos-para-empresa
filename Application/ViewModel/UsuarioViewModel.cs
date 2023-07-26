using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; }
        [DisplayName("Gerência")]
        public int Id_Gerencia { get; set; }

        public bool Ativo { get; set; }
        [DisplayName("Setor")]
        public int Id_Setor { get; set; }

        public string? ItemAtivo { get; set; }
       
        public virtual SetorViewModel? Setor { get; set; }

        public virtual GerenciaViewModel? Gerencia { get; set; }

    //    public virtual UsuarioProjetoViewModel? UsuarioProjeto { get; set; }

       
    }
}
