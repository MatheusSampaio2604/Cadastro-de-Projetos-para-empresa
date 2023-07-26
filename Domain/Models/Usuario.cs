using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        [ForeignKey("Gerencia")]
        public int Id_Gerencia { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("Setor")]
        public int Id_Setor { get; set; }

        public virtual Gerencia? Gerencia { get; set; }
        public virtual Setor? Setor { get; set; }


        public virtual ICollection<UsuarioProjeto>? UsuarioProjeto { get; set; }

    }
}
