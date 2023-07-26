using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Projeto
    {
        public DateTime HoraAbertura { get; set; }
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        [ForeignKey("Tema")]
        public int Id_Tema { get; set; }
        [ForeignKey("Objetivo")]
        public int Id_Objetivo { get; set; }

        [ForeignKey("Financiamento")]
        public int? Id_Financiamento { get; set; }

        

        public virtual ICollection<Anexos>? Anexos { get; set; }
        public virtual Tema? Tema { get; set; }
        public virtual Objetivo? Objetivo { get; set; }
        public virtual Financiamento? Financiamento { get; set; }
        public virtual IEnumerable<UsuarioProjeto>? UsuarioProjetos { get; set; }

    }
}
