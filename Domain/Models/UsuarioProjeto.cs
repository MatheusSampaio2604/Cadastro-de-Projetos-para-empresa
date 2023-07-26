using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UsuarioProjeto
    {
        public int Id_Usuario { get; set; }

        public int Id_Funcao { get; set; }

        public int Id_Projeto { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Funcao? Funcao { get; set; }
        public virtual Projeto? Projeto { get; set; }
    }
}
