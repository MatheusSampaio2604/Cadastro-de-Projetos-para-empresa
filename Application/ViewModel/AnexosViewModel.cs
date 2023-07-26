using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AnexosViewModel
    {
        public int Id { get; set; }
        public int Id_Projeto { get; set; }
        [ForeignKey("Projeto")]
        public string? Nome { get; set; }
        [DisplayName("Local Armazenado:")]
        public string? Local { get; set; }

        public virtual Projeto Projeto { get; set; }

    }
}
