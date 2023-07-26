using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Anexos
    {
        public int Id { get; set; }
        public int? Id_Projeto { get; set; }

        public string? Nome { get; set; }
        public string? Local { get; set; }

        public virtual Projeto Projetos { get; set; }

    }
}
