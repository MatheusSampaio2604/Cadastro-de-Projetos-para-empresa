using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class GerenciaViewModel
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public bool Ativo { get; set; }
        [DisplayName("Gerência Geral")]
        public int Id_GG { get; set; }
        public string? ItemAtivo { get; set; } 

        public virtual GerenciaGeralViewModel? GerenciaGeral { get; set; }  
        
        
    }
}
