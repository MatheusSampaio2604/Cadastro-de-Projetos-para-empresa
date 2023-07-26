using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Gerencia
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public bool Ativo { get; set; }

        public int Id_GG { get; set; }

        public virtual GerenciaGeral? GerenciaGeral { get; set; }

    }
}
